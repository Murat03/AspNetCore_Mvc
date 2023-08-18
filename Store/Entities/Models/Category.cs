namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set;}
        public String? CategoryName { get; set;} = string.Empty;

        public ICollection<Product> Products { get; set; } //Collection navigation property
    }
}