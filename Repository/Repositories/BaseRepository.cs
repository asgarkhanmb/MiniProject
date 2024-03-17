using Domain.Common;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T data)
        {
            throw new NotImplementedException();
        }

        public void Delete(T data)
        {
            throw new NotImplementedException();
        }

        public T Get(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
