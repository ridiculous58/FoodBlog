namespace YemekTarifi.Domain.Entities
{
    public class RecipeComment : BaseEntity
    {
        public string Comment { get; set; }
        public int Star { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
