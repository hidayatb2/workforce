using AutoMapper;
using DataAccess;
using Models;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class BidManager
    {
        private readonly BidRepository repository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;

        public BidManager(BidRepository repository, IMapper mapper, IEmailService emailService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public int CreateBid(BidRequest bidRequest,Guid userId)
        {
            Random random = new Random();

            var returnvalue = mapper.Map<BidRequest, Bid>(bidRequest);
            returnvalue.CustomerId = userId;
            returnvalue.BidStatus = BidStatus.Pending;
            returnvalue.BidNumber = random.Next();
            return repository.AddandSave(returnvalue);

        }

        public IEnumerable<BidResponse> GetBidsByCustomerId(Guid userId)
        {
            return repository.GetBidsByCustomerId(userId);

        }

        public int DeleteBid(Guid id)
        {

            return repository.DeleteBid(id);


        }

        public int UpdateBid(BidRequest bidRequest)
        {
            return repository.updateBid(bidRequest);


        }

        public IQueryable<BidShowRequest> GetAllbids()
        {

            return repository.GetAllBids();

        }
    }
}
