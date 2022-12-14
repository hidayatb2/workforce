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
            return repository.UpdateBid(bidRequest);
        }

        public IQueryable<BidShowRequest> GetAllbids()
        {
            return repository.GetAllBids();
        }

        public int AddPartcipant(PartcipantRequest partcipantRequest)
        {
            Participant participant = new()
            {
                Id= partcipantRequest.Id,
                PartcipantId = partcipantRequest.PartcipantId,
                BidId = partcipantRequest.BidId,
                BidRate = partcipantRequest.BidRate,
            };
            if (repository.FindBy<Participant>(x => x.PartcipantId == partcipantRequest.PartcipantId && x.BidId == partcipantRequest.BidId).Any()) return -1;
            return repository.AddandSave(participant);
        }

        public IEnumerable<BidResponse> GetBidsByParticipantId(Guid guid)
        {
            return repository.FindBy<Participant>(x=>x.PartcipantId == guid).IncludeNav(z=>z.Bid).Select(y=> new BidResponse
            {
                Id = y.Id,
                Address =y.Bid.Address,
                BidRate = y.Bid.BidRate,
                BidType = y.Bid.BidType,
                BidNumber = y.Bid.BidNumber,
                BidStatus = y.Bid.BidStatus,
                Discription = y.Bid.Discription,
                CustomerId = y.Bid.CustomerId,
                CreatedOn = y.Bid.CreatedOn,
            });
        }
    }
}
