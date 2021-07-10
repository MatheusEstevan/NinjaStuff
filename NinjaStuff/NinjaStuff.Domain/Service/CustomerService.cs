using NinjaStuff.Data.Context;
using NinjaStuff.Data.Repository;
using NinjaStuff.Domain.Generic;
using NinjaStuff.Domain.Interface;
using NinjaStuff.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStuff.Domain.Service
{
    public class CustomerService : BaseService<CustomerRepository,Customer>, IService
    {
        private readonly CustomerRepository customerRepository;
        public CustomerService(NinjaStuffContext context) : base(new CustomerRepository(context))
        {
            customerRepository = this.repository;
        }

        public override Customer Create(Customer entity)
        {
            if(customerRepository.List().Any(a => a.Email == entity.Email))
            {
                throw new Exception("Este cliente ja existe");
            }
            return base.Create(entity);
        }
    }
}
