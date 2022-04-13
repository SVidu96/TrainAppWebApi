using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrainAppWebApi.Data
{
    public interface ITrainAppRepo
    {
        T GetById<T>(int id) where T : class;
        DbSet<T> GetAll<T>() where T : class;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class;
        T Add<T>(T entity) where T : class;
        void AddRange<T>(IEnumerable<T> entities) where T : class;
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;
        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        T Update<T>(T entity) where T : class;
    }
}
