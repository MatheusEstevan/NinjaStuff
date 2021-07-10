using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Entities.ViewModel
{
    public class OrderViewModel
    {
        public Customer Customer { get; set; }
        public int Discount { get; set; }
        public IList<Product> Products { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

       
    }
}
