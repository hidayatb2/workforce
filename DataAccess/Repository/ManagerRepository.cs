using Models;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [ScopedService]
    public class ManagerRepository : Repository
    {

        readonly AppDbContext dbContext;

        public ManagerRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }



     


    }
}
