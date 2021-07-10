using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStuff.Domain.Generic
{
    public abstract class BaseService<IRepository, IModel>
    {
        public readonly dynamic repository;
        public BaseService(IRepository _repository)
        {
            repository = _repository;
        }

        public virtual IQueryable<IModel> List() => repository.List();
        public virtual IModel GetById(int id) => repository.GetById(id);
        public virtual IModel Create(IModel entity) => repository.Create(entity);
        public virtual IModel Update(IModel entity) => repository.Update(entity);
        public virtual int Delete(int id) => repository.Delete(id);
    }
}
