using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifi.Domain.Entities
{
    public class Food : BaseEntity
    {
        public Food()
        {
            FoodComments = new List<FoodComment>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Star { get; set; }
        public string ImageUrl { get; set; }
        public Guid FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public IList<FoodComment> FoodComments { get; set; }
    }
}
