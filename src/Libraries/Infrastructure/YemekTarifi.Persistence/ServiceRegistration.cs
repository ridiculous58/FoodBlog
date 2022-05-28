using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YemekTarifi.Application.Interfaces;
using YemekTarifi.Persistence.Repositories;
using YemekTarifi.Persistence.Services;

namespace YemekTarifi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb"); //configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeCategoryService, RecipeCategoryService>();
        }

    }
}
