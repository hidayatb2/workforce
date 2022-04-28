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
    public class LabourRepository : Repository
    {
       private readonly AppDbContext dbContext;


        public LabourRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
