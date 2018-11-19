using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Shared.Repository
{
    public interface IRepository<T> where T : Entity
    {
        T Save(T entity);
        T Update(T Entity);
        T GetById(int id);
        IEnumerable<T> GetByIds(int[] ids);
        IEnumerable<T> GetAll();
        void Delete(T entity);
    }
}
