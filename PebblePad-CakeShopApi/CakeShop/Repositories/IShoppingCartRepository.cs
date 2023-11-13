using CakeShop.Models;
using System.Collections.Generic;
using System;

namespace CakeShop.Repositories
{
    public interface IShoppingCartRepository
    {
            IEnumerable<CartItem> GetCartItems(string userId);
            bool AddToCart(string userId, CartItem cartItem);
            bool UpdateCartItemQuantity(string userId, Guid productId, int quantity);
            bool RemoveFromCart(string userId, Guid productId);
            bool ClearCart(string userId);
    }
}
