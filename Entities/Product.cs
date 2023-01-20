namespace Entities
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
