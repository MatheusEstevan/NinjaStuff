using Microsoft.EntityFrameworkCore;
using Moq;
using NinjaStuff.Data.Context;
using NinjaStuff.Domain.Service;
using NinjaStuff.Entities.Model;
using NinjaStuff.Entities.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStuff.Test.OrderTest
{
    class OrderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNewProduct()
        {
            OrderService service;
            var mockOrderSet = new Mock<DbSet<Order>>();
            var data = new List<Order>().AsQueryable();
            mockOrderSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockOrderSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockOrderSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockOrderSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<NinjaStuffContext>();
            mockContext.Setup(m => m.Set<Order>()).Returns(mockOrderSet.Object);


            service = new OrderService(mockContext.Object);

            var a = new OrderViewModel()
            {
                Customer = new Customer()
                {
                    Email = "teste@teste.com",
                    Name = "Teste",
                    Village = "Konoha"

                },
                Discount = 10,
                Price = 20,
                TotalPrice = 10,
                Products = new List<Product>()
                {
                      new Product {
                          Description = "Kunai",
                          Price = 11.3,
                          Picture = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Kunai05.jpg"
                      }

                }
            };

            service.Create(a);
            mockOrderSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
