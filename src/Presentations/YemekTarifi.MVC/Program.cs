using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Reflection;
using YemekTarifi.Application;
using YemekTarifi.MVC.Models;
using YemekTarifi.Persistence;
using YemekTarifi.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services,builder.Configuration);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

await MigrateDatabase(app);

app.Run();



void ConfigureServices(IServiceCollection services,IConfiguration configuration)
{
    services.AddApplicationServices(configuration);
    services.AddPersistenceServices(configuration);

    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

    services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

    services.ConfigureApplicationCookie(configure =>
    {
        configure.LoginPath = "/identity/login";
        configure.LogoutPath = "/identity/logout";
    });

    var urlViewModel = new LayoutUrlViewModel();
    
    urlViewModel.UrlViewModels.Add(new UrlViewModel
    {
        IconName = "dashboard",
        Text = "Dashboard",
        Url = "/admin/home/index"
    });
    
    urlViewModel.UrlViewModels.Add(new UrlViewModel
    {
        IconName = "table_view",
        Text = "Eat",
        Url = "/admin/home/eat"
    });

    services.AddSingleton(urlViewModel);
}




async Task MigrateDatabase(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await AddSeedData(scope,context);
    if (!context.Database.IsInMemory())
    {
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
}

async Task AddSeedData(IServiceScope scope, ApplicationDbContext context)
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roleExist = await roleManager.RoleExistsAsync("Admin");
    if (!roleExist)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("User"));
        
    }
   
}