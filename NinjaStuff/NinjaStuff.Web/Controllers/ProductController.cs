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
    public class ProductController : BaseController<ProductService,Product>
    {
        private readonly ProductService ProductService;
        public ProductController([FromServices]NinjaStuffContext applicationDbContext ) : base(new ProductService(applicationDbContext))
        {
            ProductService = new ProductService(applicationDbContext);

        }
    }
}