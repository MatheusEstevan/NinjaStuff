using NinjaStuff.Data.Context;
using NinjaStuff.Data.Repository;
using NinjaStuff.Domain.Generic;
using NinjaStuff.Domain.Interface;
using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaStuff.Domain.Service
{
    public class ProductService : BaseService<ProductRepository, Product>, IService
    {
        private readonly ProductRepository productRepository;
        public ProductService(NinjaStuffContext context) : base(new ProductRepository(context))
        {
            productRepository = this.repository;
        }

        public override Product Create(Product entity)
        {
            if (entity.Price <= 0)
            {
                throw new Exception("Preço inválido");
            }
            return base.Create(entity);
        }
    }
}
