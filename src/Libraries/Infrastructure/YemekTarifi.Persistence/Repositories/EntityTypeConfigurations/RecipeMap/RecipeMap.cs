using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Repositories.EntityTypeConfigurations.RecipeMap
{
    public class RecipeMap : BaseEntityMap<Recipe>
    {
        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            
            builder.Property(x => x.Description).IsRequired(false);
            builder.HasIndex(f => f.Name).IncludeProperties(x=>x.ImageUrl).HasFillFactor(70).HasDatabaseName("IX1_NAME");
            base.Configure(builder);


        }
    }
}
