using System;
using System.Collections.Generic;
using System.Linq;
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
        public int AddandSave<T>(T model) where T : class
        {
            dbContext.Set<T>().Add(model);
            return dbContext.SaveChanges();
        }
    }
}
