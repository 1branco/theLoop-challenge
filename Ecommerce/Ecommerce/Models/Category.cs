namespace Ecommerce.Models
{
    public class Category
    {
        public string Name { get; set; }
    }

    public class CategoryDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
