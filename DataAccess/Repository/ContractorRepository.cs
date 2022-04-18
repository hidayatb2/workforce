using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ContractorRepository : Repository
    {

        readonly AppDbContext dbContext;

        public ContractorRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Manager> GetManagers()
        {
           return dbContext.Set<Manager>();
        }

    }
}
