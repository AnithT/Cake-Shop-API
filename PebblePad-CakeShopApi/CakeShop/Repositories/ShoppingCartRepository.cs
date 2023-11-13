using CakeShop.Data;
using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeShop.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ILiteDBProvider<CartItem> liteDBProvider;

        public ShoppingCartRepository(ILiteDBProvider<CartItem> liteDBProvider)
        {
            this.liteDBProvider = liteDBProvider;
        }

        public bool AddToCart(string userId, CartItem cartItem)
        {
            cartItem.Userid = userId;
            liteDBProvider.Create(cartItem);
            return true;
        }

        public bool ClearCart(string userId)
        {
            var cartItems = liteDBProvider.GetAll().ToArray();
            foreach (var cartItem in cartItems.Where(x=> x.Userid == userId))
            {
                liteDBProvider.Delete(cartItem.Id);
            }
            return true;
        }

        public IEnumerable<CartItem> GetCartItems(string userId)
        {
            return liteDBProvider.GetAll().ToArray().Where(x=> x.Userid == userId);

        }

        public bool RemoveFromCart(string userId, Guid productId)
        {
            var cartItem = liteDBProvider.Get(productId);
            if (cartItem != null)
            {
                liteDBProvider.Delete(cartItem.Id);
                return true;
            }
            return false;
        }

        public bool UpdateCartItemQuantity(string userId, Guid productId, int quantity)
        {
            var cartItem = liteDBProvider.GetAll().ToArray().Where(item => item.Userid == userId && item.Id == productId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                liteDBProvider.Update(cartItem);
                return true;
            }
            return false;
        }
    }
}
