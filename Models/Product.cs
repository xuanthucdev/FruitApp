using System.ComponentModel.DataAnnotations;

namespace ProjectDotNet.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Image { get; set; } = null!;

        public virtual Category category { get; set; }
        public virtual ICollection<ProductKeyWord> Productkeywords { get; set; } = new List<ProductKeyWord>();

        [Required]
        public int Stock { get; set; }

    }
}
                                