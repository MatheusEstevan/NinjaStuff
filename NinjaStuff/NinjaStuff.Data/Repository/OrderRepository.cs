using NinjaStuff.Data.Context;
using NinjaStuff.Data.Generic;
using NinjaStuff.Data.Interface;
using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Data.Repository
{
    public class OrderRepository : BaseRepository<Order>, IRepository<Order>
    {
        private readonly NinjaStuffContext _context;
        public OrderRepository(NinjaStuffContext context) : base(context)
        {
            _context = context;
        }
    }
}
