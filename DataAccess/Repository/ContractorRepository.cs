using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    [ScopedService]
    public class ContractorRepository : Repository
    {

        readonly AppDbContext dbContext;


        public ContractorRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

     

    }
}
