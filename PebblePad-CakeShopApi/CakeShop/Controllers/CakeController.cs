using System;
using System.Collections.Generic;
using System.Linq;
using CakeShop.Models;
using CakeShop.Repositories;
using CakeShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private ICakeRepository cakeRepository;
        //private IShoppingCartService shoppingCartService;

        public CakeController(ICakeRepository cakeRepository)
        {
            this.cakeRepository = cakeRepository;
            //this.shoppingCartService = shoppingCartService;
        }

        // GET api/cake
        [HttpGet]
        public ActionResult<IEnumerable<Cake>> Get()
        {
            return cakeRepository.All().ToArray();
        }

        // GET api/cake/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpGet("{id}")]
        public ActionResult<Cake> Get(Guid id)
        {
            return this.cakeRepository.GetById(id);
        }

        // POST api/book
        [HttpPost]
        public bool Post([FromBody] Cake value)
        {
            return this.cakeRepository.Add(value);
        }

        // PUT api/cake/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] Cake value)
        {
            value.Id = id;
            var cake = this.cakeRepository.GetById(id);
            if (cake == null)
            {
                return this.cakeRepository.Add(value);
            } else
            {
                return this.cakeRepository.Update(value);
            }
        }

        // DELETE api/cake/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return this.cakeRepository.Delete(id);
        }

        //[HttpPost("addToCart/{id}")]
        //public ActionResult<bool> AddToCart(Guid id, [FromBody] int quantity)
        //{
        //    var cake = this.cakeRepository.GetById(id);

        //    if (cake == null)
        //    {
        //        return NotFound();
        //    }

        //    this.shoppingCartService.AddItem(cake, quantity);
        //    return true;
        //}
        //// POST api/cake/removeFromCart/{id}
        //[HttpPost("removeFromCart/{id}")]
        //public ActionResult<bool> RemoveFromCart(Guid id)
        //{
        //    this.shoppingCartService.RemoveItem(id);
        //    return true;
        //}

        //// POST api/cake/clearCart
        //[HttpPost("clearCart")]
        //public ActionResult<bool> ClearCart()
        //{
        //    this.shoppingCartService.ClearCart();
        //    return true;
        //}
    }
}
