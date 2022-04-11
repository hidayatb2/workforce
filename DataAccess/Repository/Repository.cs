using System;
using System.Collections.Generic;
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


        public IEnumerable<T> GetAllUsers<T>() where T : class
        {
            return dbContext.Set<T>();
        }


        public int AddandSave<T>(T model) where T : class
        {
            dbContext.Set<T>().Add(model);
            return dbContext.SaveChanges();
        }

        IEnumerable<T> IRepository.FindBy<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return dbContext.Set<T>().Where(expression);

        }

        bool IRepository.IsExist<T>(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Any(expression);
        }


       



    }
}
