﻿using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class HomeManager
    {

        private readonly IRepository repository;
        public HomeManager(IRepository repository)
        {
          this.repository = repository;
        }

        public int AddContactUsMessage(ContactUsRequest contactUsRequest)
        {
            ContactUs contactUs = new ContactUs()
            {
                Id = Guid.NewGuid(),
                Name = contactUsRequest.Name,
                Email = contactUsRequest.Email,
                PhoneNo = contactUsRequest.PhoneNo,
                Message = contactUsRequest.Message
            };
           return repository.AddandSave<ContactUs>(contactUs);

        }

    }
}
