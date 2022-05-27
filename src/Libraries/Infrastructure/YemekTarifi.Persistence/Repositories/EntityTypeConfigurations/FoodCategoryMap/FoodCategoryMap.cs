using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Repositories.EntityTypeConfigurations.FoodCategoryMap
{
        public class FoodCategoryMap : BaseEntityMap<FoodCategory>
        {
            public override void Configure(EntityTypeBuilder<FoodCategory> builder)
            {

                builder.HasIndex(f => f.Name).IncludeProperties(x => x.Description).HasFillFactor(70).HasDatabaseName("IX1_NAME");
                base.Configure(builder);


            }
        }
}
