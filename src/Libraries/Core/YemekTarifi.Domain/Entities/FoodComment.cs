namespace YemekTarifi.Domain.Entities
{
    public class FoodComment : BaseEntity
    {
        public string Comment { get; set; }
        public int Star { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}
