using NinjaStuff.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Entities.Model
{
    public class OrderProduct : IModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
