using NinjaStuff.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Entities.Model
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }

    }
}
