namespace ProjectDotNet.Models
{
    public class ProductWithCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDes { get; set; }
        public int Stock {  get; set; }
    }
}
