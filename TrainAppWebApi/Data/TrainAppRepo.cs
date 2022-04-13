using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrainAppWebApi.Data
{
    public class TrainAppRepo : ITrainAppRepo
    {
        private readonly PurchasedTicketContext _context;

        public TrainAppRepo(PurchasedTicketContext context)
        {
                _context = context;
        }
        public T Add<T>(T entity) where T : class
        {
            var currentEntity = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return currentEntity;
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _context.Set<T>().Where(expression);
        }

        public DbSet<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public T Update<T>(T entity) where T : class
        {
            var currentEntity = _context.Set<T>().Update(entity).Entity;
            _context.SaveChanges();
            return currentEntity;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
        }
    }
}
