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


        public IEnumerable<BidResponse> GetBidsByCustomerId(Guid userId)
        {

            var query = @$"  select * from Bids where CustomerId ='{userId}' ";
            var result = FromQuery<BidResponse>(query);
            return result;
        }
    }
}
