using NinjaStuff.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStuff.Entities.Model
{
    public class Customer 
    {   
        public string Name { get; set; }
        public string Email { get; set; }
        public string Village { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
