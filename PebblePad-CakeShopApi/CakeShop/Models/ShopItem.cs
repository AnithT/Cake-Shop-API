using System;
using System.Collections.Generic;

namespace CakeShop.Models
{
    public abstract class ShopItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public string Creator { get; set; }
        public DateTime Added { get; set; }
        public float Price { get; set; }
        public IList<string> Ingredients { get; set; }
    }
}
