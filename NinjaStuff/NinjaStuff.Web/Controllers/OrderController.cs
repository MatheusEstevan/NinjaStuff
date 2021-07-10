using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NinjaStuff.Data.Context;
using NinjaStuff.Domain.Service;
using NinjaStuff.Entities.Model;
using NinjaStuff.Entities.ViewModel;
using NinjaStuff.Web.Generic;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace NinjaStuff.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<OrderService,Order>
    {
        private readonly OrderService orderService;
        public OrderController([FromServices]NinjaStuffContext applicationDbContext ) : base(new OrderService(applicationDbContext))
        {
            orderService = new OrderService(applicationDbContext);

        }

        [HttpPost("New")]
        [ProducesResponseType(typeof(object), Status200OK)]
        public IActionResult Post([FromBody] OrderViewModel data)
        {
            try
            {
                return Ok(orderService.Create(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}