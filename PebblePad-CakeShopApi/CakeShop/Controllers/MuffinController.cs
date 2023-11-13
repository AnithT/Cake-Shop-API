using System;
using System.Collections.Generic;
using System.Linq;
using CakeShop.Models;
using CakeShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MuffinShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuffinController : ControllerBase
    {
        private IMuffinRepository muffinRepository;

        public MuffinController(IMuffinRepository muffinRepository)
        {
            this.muffinRepository = muffinRepository;
        }

        // GET api/muffin
        [HttpGet]
        public ActionResult<IEnumerable<Muffin>> Get()
        {
            return muffinRepository.All().ToArray();
        }

        // GET api/muffin/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpGet("{id}")]
        public ActionResult<Muffin> Get(Guid id)
        {
            return this.muffinRepository.GetById(id);
        }

        // POST api/book
        [HttpPost]
        public bool Post([FromBody] Muffin value)
        {
            return this.muffinRepository.Add(value);
        }

        // PUT api/muffin/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] Muffin value)
        {
            value.Id = id;
            var muffin = this.muffinRepository.GetById(id);
            if (muffin == null)
            {
                return this.muffinRepository.Add(value);
            } else
            {
                return this.muffinRepository.Update(value);
            }
        }

        // DELETE api/muffin/d17eeb84-6d52-49b7-b30c-f4b041016aca
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return this.muffinRepository.Delete(id);
        }
    }
}
