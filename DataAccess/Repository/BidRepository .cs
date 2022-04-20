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
    public class BidRepository : Repository
    {
        readonly AppDbContext dbContext;
        public BidRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CreateBid(BidRequest bidRequest)
        {
            throw new NotImplementedException();
        }
    }
}
