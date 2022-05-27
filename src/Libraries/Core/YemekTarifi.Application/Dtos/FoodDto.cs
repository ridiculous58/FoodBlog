using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifi.Domain;

namespace YemekTarifi.Application.Dtos
{
    public class FoodDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int Star { get; set; }
        public string ImageUrl { get; set; }

        public string FoodCategoryId { get; set; }
    }


}
