using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifi.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            RecipeComments = new List<RecipeComment>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public string ImageUrl { get; set; }
        public Guid RecipeCategoryId { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
        public IList<RecipeComment> RecipeComments { get; set; }
    }
}
