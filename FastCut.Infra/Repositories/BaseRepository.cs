using FastCut.Infra.Datas;
using FastCut.Shared.Entities;
using FastCut.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Infra.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(IContextFactory contextFactory)
        {
            _context = contextFactory.DbContext;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            _dbSet.Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public T Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
