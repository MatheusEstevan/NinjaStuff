using Microsoft.EntityFrameworkCore;
using Moq;
using NinjaStuff.Data.Context;
using NinjaStuff.Domain.Service;
using NinjaStuff.Entities.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStuff.Test.ProductTest
{
    class ProductTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNewProduct()
        {
            ProductService service;
            var mockProductSet = new Mock<DbSet<Product>>();
            var data = new List<Product>().AsQueryable();
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<NinjaStuffContext>();
            mockContext.Setup(m => m.Set<Product>()).Returns(mockProductSet.Object);


            service = new ProductService(mockContext.Object);

            var a = new Product()
            {
                Description = "Kunai",
                Price = 11.3,
                Picture = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Kunai05.jpg"
            };

            service.Create(a);
            mockProductSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
