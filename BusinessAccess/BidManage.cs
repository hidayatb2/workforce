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
        private readonly IEmailService emailService;

        public BidManager(BidRepository repository, IEmailService emailService)
        {
            this.repository = repository;
            this.emailService = emailService;
        }

        public int CreateBid(BidRequest bidRequest)
        {
            return repository.CreateBid(bidRequest);

        }
    }
}
