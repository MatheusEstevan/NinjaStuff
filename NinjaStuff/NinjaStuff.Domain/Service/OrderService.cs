using NinjaStuff.Data.Context;
using NinjaStuff.Data.Repository;
using NinjaStuff.Domain.Generic;
using NinjaStuff.Domain.Interface;
using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Domain.Service
{
    public class OrderService: BaseService<OrderRepository,Order>, IService
    {
        public OrderService(NinjaStuffContext context) : base(new OrderRepository(context))
        {
         
        }

    
    }
}
