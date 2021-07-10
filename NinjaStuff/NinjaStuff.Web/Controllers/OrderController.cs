using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NinjaStuff.Data.Context;
using NinjaStuff.Domain.Service;
using NinjaStuff.Entities.Model;
using NinjaStuff.Web.Generic;

namespace NinjaStuff.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<OrderService,Order>
    {
        private readonly OrderService OrderService;
        public OrderController([FromServices]NinjaStuffContext applicationDbContext ) : base(new OrderService(applicationDbContext))
        {
            OrderService = new OrderService(applicationDbContext);

        }
    }
}