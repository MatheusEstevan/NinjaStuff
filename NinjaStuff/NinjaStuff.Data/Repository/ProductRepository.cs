using NinjaStuff.Data.Context;
using NinjaStuff.Data.Generic;
using NinjaStuff.Data.Interface;
using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IRepository<Product>
    {
        private readonly NinjaStuffContext _context;
        public ProductRepository(NinjaStuffContext context) : base(context)
        {
            _context = context;
        }
    }
}
