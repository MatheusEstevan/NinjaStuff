using NinjaStuff.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Entities.Model
{
    public class Order : IModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }
        public Customer Customer { get; set; }

    }
}
