namespace ProjectDotNet.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryID { get; set; }
        public int Price { get; set; }
        
        public string Image { get; set; } = null!;


    }
}
                                