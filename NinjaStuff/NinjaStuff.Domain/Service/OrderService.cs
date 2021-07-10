using NinjaStuff.Data.Context;
using NinjaStuff.Data.Repository;
using NinjaStuff.Domain.Generic;
using NinjaStuff.Domain.Interface;
using NinjaStuff.Entities.Model;
using NinjaStuff.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Domain.Service
{
    public class OrderService: BaseService<OrderRepository,Order>, IService
    {
        private readonly OrderRepository orderRepository;
        public OrderService(NinjaStuffContext context) : base(new OrderRepository(context))
        {
            orderRepository = this.repository;
        }

        public Order Create(OrderViewModel entity)
        {
            Order order = Order.mapFromViewModel(entity);
            foreach(Product product in entity.Products)
            {
                order.OrderProducts = new List<OrderProduct>();
                order.OrderProducts.Add(new OrderProduct()
                {
                    ProductId = product.Id,
                    
                }) ;
            }
           // entity.
            return base.Create(order);
        }
    }
}
