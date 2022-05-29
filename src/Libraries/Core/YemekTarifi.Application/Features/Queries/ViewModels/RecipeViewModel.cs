using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifi.Application.Features.Queries.ViewModels
{
    public class RecipeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Star { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public string RecipeCategoryId { get; set; }
        public RecipeCategoryViewModel RecipeCategory { get; set; }
        public IList<RecipeCommentsViewModel> RecipeComments { get; set; }
    }
}
