using System.Collections.Generic;
using System;
using CakeShop.Models;
using System.Linq;
using CakeShop.Repositories;

namespace CakeShop.Services
{
    public class ShoppingCartService: IShoppingCartService
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly ICakeRepository cakeRepository;
        private readonly IMuffinRepository muffinRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,
                                   ICakeRepository cakeRepository,
                                   IMuffinRepository muffinRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.cakeRepository = cakeRepository;
            this.muffinRepository = muffinRepository;
        }

        public IEnumerable<CartItem> GetCartItems(string userId)
        {
            var cartItems = shoppingCartRepository.GetCartItems(userId);
            return cartItems;
        }

        public bool AddToCart(string userId, CartItem cartItem)
        {
            ApplyTwoForOneOffer(cartItem);
            return shoppingCartRepository.AddToCart(userId, cartItem);
        }

        public bool UpdateCartItemQuantity(string userId, Guid productId, int quantity)
        {
            var cartItems = shoppingCartRepository.GetCartItems(userId);
            var cartItem = cartItems.FirstOrDefault(item => item.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                ApplyTwoForOneOffer(cartItem);
                return shoppingCartRepository.UpdateCartItemQuantity(userId, productId, quantity);
            }
            return false;
        }

        public bool RemoveFromCart(string userId, Guid productId)
        {
            return shoppingCartRepository.RemoveFromCart(userId, productId);
        }

        public bool ClearCart(string userId)
        {
            return shoppingCartRepository.ClearCart(userId);
        }

        private void ApplyTwoForOneOffer(CartItem cartItem)
        {
           
                if (cartItem.Type == ProductType.Muffin && cartItem.Quantity % 2 == 0)
                {
                    cartItem.TotalPrice = cartItem.Price * (cartItem.Quantity / 2);
                }
                else
                {
                    cartItem.TotalPrice = cartItem.Price * cartItem.Quantity;
                }
        }
    }
}
