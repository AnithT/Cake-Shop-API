using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Cake : ShopItem
    {
        public int CaloriesPerSlice { get; set; }
        public string Recipe { get; set; }
        public float RecipePrice { get; set; }
    }
}
