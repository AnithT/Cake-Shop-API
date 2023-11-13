using CakeShop.Models;
using System;
using System.Collections.Generic;

namespace CakeShop.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<CartItem> GetCartItems(string userId);
        bool AddToCart(string userId, CartItem cartItem);
        bool UpdateCartItemQuantity(string userId, Guid productId, int quantity);
        bool RemoveFromCart(string userId, Guid productId);
        bool ClearCart(string userId);

    }
}
