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
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetByIds(int[] ids)
        {
            return _dbSet.Where(x => ids.Contains(x.Id));
        }

        public T Save(T entity)
        {
            _dbSet.Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);

            _context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);

            _context.SaveChanges();
            
        }
    }
}
