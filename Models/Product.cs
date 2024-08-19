﻿using System.ComponentModel.DataAnnotations;

namespace ProjectDotNet.Models
{
    public class Product
    {
        public int Id { get; set; }
     
        public string Name { get; set; } = null!;
        public string Description { get; set; } 
        public int CategoryID { get; set; }
        
        public int Price { get; set; }
        
        public string Image { get; set; } = null!;
        public virtual Category category { get; set; }
        public virtual ICollection<ProductKeyWord> Productkeywords { get; set; } = new List<ProductKeyWord>();
        public int Stock {  get; set; }


    }
}
                                