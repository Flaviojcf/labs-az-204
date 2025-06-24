namespace QueueFunctionApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Category: {Category}, Description: {Description}, Price: {Price}";
        }

    }
}
