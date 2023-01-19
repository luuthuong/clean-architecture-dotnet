using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Category: EntityBase
    {
        public string Name { get; set; }
        [ForeignKey("ParentId")]
        public Guid? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
