namespace CakeShop.Models
{
    public class CartItem:ShopItem
    {
        public string Userid { get; set; }

        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
    }
}
