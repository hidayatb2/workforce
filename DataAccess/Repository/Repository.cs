using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T GetById<T>(Guid id) where T : class
        {
            return dbContext.Set<T>().Find(id);
        }


        public int AddandSave<T>(T model) where T : class
        {
            dbContext.Set<T>().Add(model);
            return dbContext.SaveChanges();
        }

        public IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public bool IsExist<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return dbContext.Set<T>().Any(predicate);
        }

        public int Delete<T>(T model) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllUsers<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
   
}
