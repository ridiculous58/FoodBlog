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
using System.Text;
using Microsoft.AspNetCore.Builder;
using YemekTarifi.Application;
using YemekTarifi.Application.Dtos;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Domain.Entities;
using YemekTarifi.MVC.Models;
using YemekTarifi.Persistence;
using YemekTarifi.Persistence.Repositories;
using YemekTarifi.Persistence.Services;

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

// app.Use(async (context, next) =>
// {
//     try
//     {
//         await next(context);
//     }
//     catch (Exception e)
//     {
//         context.Response.Redirect($"/Home/Error");
//     }
// });

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
        Text = "Recipe",
        Url = "/admin/home/recipe"
    });

    services.AddSingleton(urlViewModel);
}




async Task MigrateDatabase(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!context.Database.IsInMemory())
    {
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
    await AddSeedData(scope,context);
}

async Task AddSeedData(IServiceScope scope, ApplicationDbContext context)
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleExist = await roleManager.RoleExistsAsync("Admin");
    if (!roleExist)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("User"));
        
    }

    if (!context.Users.Any())
    {
        var identityUser = new IdentityUser()
        {
            Email = "zeynep@zec.com",
            UserName = "zeynep",
        };
        var result = await userManager.CreateAsync(identityUser, "Zeynep@1234");
        if (result.Succeeded)
        {
            await userManager.AddToRolesAsync(identityUser, new []{"Admin","User"});    
        }
        

    } 
   

    var recipeService = scope.ServiceProvider.GetRequiredService<IRecipeService>();
    var recipeCategoryService = scope.ServiceProvider.GetRequiredService<IRecipeCategoryService>();
   
    var pizzaCategory = await recipeCategoryService.InsertAsync(new RecipeCategory()
    {
        Name = "Pizza Category",
        Description = "Pizza Category"
    });
    
    var pastaCategory = await recipeCategoryService.InsertAsync(new RecipeCategory()
    {
        Name = "Pasta Category",
        Description = "Pasta Category"
    });
    
    var cakeCategory = await recipeCategoryService.InsertAsync(new RecipeCategory()
    {
        Name = "Cake Category",
        Description = "Cake Category"
    });
    
    await recipeService.InsertManyAsync(new[]
    {
        new Recipe()
        {
            ImageUrl = "/images/recipes/1.jpg",
            Name = "Traditional Pizza",
            RecipeCategoryId = pizzaCategory.Id,
            Star = 1,
            IsActive = false
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/2.jpg",
            Name = "Italian home-made pasta",
            RecipeCategoryId = pastaCategory.Id,
            Star = 4
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/3.jpg",
            Name = "Chesse Cake Tart",
            RecipeCategoryId = cakeCategory.Id,
            Star = 4,
            IsActive = false
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/4.jpg",
            Name = "Traditional Pizza",
            RecipeCategoryId = pizzaCategory.Id,
            Star = 2
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/5.jpg",
            Name = "Italian home-made pasta",
            RecipeCategoryId = pastaCategory.Id,
            Star = 2,
            IsActive = false
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/6.jpg",
            Name = "Chesse Cake Tart",
            RecipeCategoryId = cakeCategory.Id,
            Star = 2
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/7.jpg",
            Name = "Traditional Pizza",
            RecipeCategoryId = pizzaCategory.Id,
            Star = 2
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/8.jpg",
            Name = "Italian home-made pasta",
            RecipeCategoryId = pastaCategory.Id,
            Star = 2
        },
        new Recipe()
        {
            ImageUrl = "/images/recipes/9.jpg",
            Name = "Chesse Cake Tart",
            RecipeCategoryId = cakeCategory.Id,
            Star = 2
        }
    });
}