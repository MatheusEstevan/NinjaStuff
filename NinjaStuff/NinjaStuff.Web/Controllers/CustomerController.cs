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
    public class CustomerController : BaseController<CustomerService,Customer>
    {
        private readonly CustomerService customerService;
        public CustomerController([FromServices]NinjaStuffContext applicationDbContext ) : base(new CustomerService(applicationDbContext))
        {
            customerService = new CustomerService(applicationDbContext);

        }
    }
}