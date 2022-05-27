using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Repositories.EntityTypeConfigurations.FoodCommentMap
{
    public class FoodCommentMap : BaseEntityMap<FoodComment>
    {
        public override void Configure(EntityTypeBuilder<FoodComment> builder)
        {

            builder.HasIndex(f => f.Name)
                .IncludeProperties(nameof(FoodComment.Star), nameof(FoodComment.Comment))
                .HasFillFactor(70)
                .HasDatabaseName("IX1_NAME");

            base.Configure(builder);
        }

    }
}
