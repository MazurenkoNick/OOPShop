namespace OOPShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Product(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
