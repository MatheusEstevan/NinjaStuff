using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using NinjaStuff.Domain.Interface;


namespace NinjaStuff.Web.Generic
{
    public abstract class BaseController<T, U> : ControllerBase
    {
        private readonly dynamic service;
        public BaseController(IService _service)
        {
            service = _service;
        }


        [HttpGet]
        [ProducesResponseType(typeof(object), Status200OK)]
        public virtual IActionResult Get() => Ok(service.List());

        //[HttpGet("{id}")]

        //[ProducesResponseType(typeof(object), Status200OK)]
        //public virtual IActionResult Get(long key) => Ok(service.GetById(key));

        [HttpPost]
        [ProducesResponseType(typeof(object), Status200OK)]
        public virtual IActionResult Post([FromBody] U data) {
            try
            {
                return Ok(service.Create(data));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [ProducesResponseType(typeof(object), Status200OK)]
        public virtual IActionResult Put([FromBody] U data) => Ok(service.Update(data));

        [HttpDelete]
        [ProducesResponseType(typeof(object), Status200OK)]
        public virtual IActionResult Delete(int key) => Ok(service.Delete(key));

    }
}
