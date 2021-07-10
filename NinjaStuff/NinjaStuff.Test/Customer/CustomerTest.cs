using NinjaStuff.Data.Context;
using NinjaStuff.Domain.Service;
using NUnit.Framework;
using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NinjaStuff.Test.CustomerTests
{
    class CustomerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNewCustomer()
        {
            CustomerService service;
            var mockCustomerSet = new Mock<DbSet<Customer>>();
            var data = new List<Customer>().AsQueryable();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<NinjaStuffContext>();
            mockContext.Setup(m => m.Set<Customer>()).Returns(mockCustomerSet.Object);
           
            
            service = new CustomerService(mockContext.Object);

            var a = new Customer()
            {
                Email = "teste@teste.com",
                Name = "Teste",
                 Village = "Konoha"
            };

            service.Create(a);
            mockCustomerSet.Verify(m => m.Add(It.IsAny<Customer>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
