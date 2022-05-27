using YemekTarifi.Domain;

namespace YemekTarifi.Application.Dtos
{
    public class FoodCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }


}
