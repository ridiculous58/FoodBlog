using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain.Entities;

namespace YemekTarifi.Persistence.Repositories.EntityTypeConfigurations.RecipeCommentMap
{
    public class RecipeCommentMap : BaseEntityMap<RecipeComment>
    {
        public override void Configure(EntityTypeBuilder<RecipeComment> builder)
        {

            builder.HasIndex(f => f.Name)
                .IncludeProperties(nameof(RecipeComment.Star), nameof(RecipeComment.Comment))
                .HasFillFactor(70)
                .HasDatabaseName("IX1_NAME");

            base.Configure(builder);
        }

    }
}
