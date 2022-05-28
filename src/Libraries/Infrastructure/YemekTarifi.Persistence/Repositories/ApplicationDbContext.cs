using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Application.Interfaces;

namespace YemekTarifi.Persistence.Repositories
{
    public class ApplicationDbContext : IdentityDbContext , IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public async Task<bool> SaveChangesAsync()
        {
            await base.SaveChangesAsync();
            return true;
        }
        bool IUnitOfWork.SaveChanges()
        {
            SaveChanges();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        
    }
}
