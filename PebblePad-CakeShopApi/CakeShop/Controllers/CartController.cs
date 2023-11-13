using CakeShop.Models;
using CakeShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace CakeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly ICakeRepository cakeRepository;
        private readonly IMuffinRepository muffinRepository;

        public CartController(IShoppingCartRepository shoppingCartRepository,
                                      ICakeRepository cakeRepository,
                                      IMuffinRepository muffinRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.cakeRepository = cakeRepository;
            this.muffinRepository = muffinRepository;
        }
        // GET api/shoppingcart/{userId}
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<CartItem>> Get(string userId)
        {
            var cartItems = shoppingCartRepository.GetCartItems(userId);
            return Ok(cartItems);
        }

        // POST api/shoppingcart/{userId}
        [HttpPost("{userId}")]
        public ActionResult<bool> AddToCart(string userId, [FromBody] CartItem cartItem)
        {
            // Check the type of the product and add it to the appropriate repository
            if (cartItem.Type == ProductType.Cake)
            {
                var cake = cakeRepository.GetById(cartItem.Id);
                if (cake != null)
                {
                    cartItem.Price = cake.Price;
                    return Ok(shoppingCartRepository.AddToCart(userId, cartItem));
                }
            }
            else if (cartItem.Type == ProductType.Muffin)
            {
                var muffin = muffinRepository.GetById(cartItem.Id);
                if (muffin != null)
                {
                    cartItem.Price = muffin.Price;
                    return Ok(shoppingCartRepository.AddToCart(userId, cartItem));
                }
            }

            return BadRequest("Invalid product type or product not found.");
        }

        // PUT api/shoppingcart/{userId}/{productId}
        [HttpPut("{userId}/{productId}")]
        public ActionResult<bool> UpdateCartItemQuantity(string userId, Guid productId, [FromBody] int quantity)
        {
            return Ok(shoppingCartRepository.UpdateCartItemQuantity(userId, productId, quantity));
        }

        // DELETE api/shoppingcart/{userId}/{productId}
        [HttpDelete("{userId}/{productId}")]
        public ActionResult<bool> RemoveFromCart(string userId, Guid productId)
        {
            return Ok(shoppingCartRepository.RemoveFromCart(userId, productId));
        }

        // DELETE api/shoppingcart/{userId}
        [HttpDelete("{userId}")]
        public ActionResult<bool> ClearCart(string userId)
        {
            return Ok(shoppingCartRepository.ClearCart(userId));
        }
    }
}
