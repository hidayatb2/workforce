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

            var query = @$"  select * from Bids where CustomerId ='{userId}' order By CreatedOn Desc";
            var result = FromQuery<BidResponse>(query);
            return result;
        }

        public int DeleteBid(Guid id)
        {
            string query = $@" Delete from Bids WHERE id ='{id}' ";
            return ExecuteQuery(query);

        }

        public int updateBid(BidRequest bidRequest)
        {

            string query = $@"update Bids set BidType ='{bidRequest.BidType}', Discription='{bidRequest.Discription}',
                                BidRate='{bidRequest.BidRate}',Address='{bidRequest.Address}'
                                where id ='{bidRequest.Id}' ";
            return ExecuteQuery(query);
        }

        public IQueryable<BidShowRequest> GetAllBids()
        {
            string query = $@" select Bids.Id, users.Email,bids.BidNumber,Bids.BidStatus,Users.PhoneNo,Users.UserName,Bids.BidType,bids.Discription,Bids.BidRate,bids.Address,bids.CustomerId,bids.CreatedOn from Users
                                INNER JOIN Bids
                                ON Users.Id=Bids.CustomerId
                                where UserRole=2 ";
            return FromQuery<BidShowRequest>(query);
        }
    }
}
