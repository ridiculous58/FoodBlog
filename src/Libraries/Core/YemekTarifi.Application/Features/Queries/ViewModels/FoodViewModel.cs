using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifi.Application.Features.Queries.ViewModels
{
    public class FoodViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Star { get; set; }
        public string ImageUrl { get; set; }
        public FoodCategoryViewModel FoodCategory { get; set; }
        public IList<FoodCommentsViewModel> FoodComments { get; set; }
    }
}
