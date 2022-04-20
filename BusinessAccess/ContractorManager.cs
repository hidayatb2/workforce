﻿using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class ContractorManager
    {

        readonly ContractorRepository contractorRepository;

        public ContractorManager(ContractorRepository contractorRepository)
        {
            this.contractorRepository = contractorRepository;
        }

        public IEnumerable<GeneralResponse> GetManagers()
        {
            return contractorRepository.GetAll<Manager>().Select(x => new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                UserName = x.UserName,
                Status =BidStatus.Pending,


            });
        }



        public string PostRequest(RequestDb requestDb)
        {

            GeneralRequestDB generalRequestDB = new GeneralRequestDB()
            {
                Id = new Guid(),
                Name = requestDb.Name,
                Message = requestDb.Description,
                UserRole = UserRole.Manager,
                SenderId = requestDb.SenderId,
                RecieverId=requestDb.RecieverId


            };

            var returnVal = contractorRepository.AddandSave(generalRequestDB);
            if (returnVal != 0)
            {
                return "Success";
            }
            else
            {
                return "Error";
            }

        }

        public IEnumerable<ResponseDb> GetRequestMessages(Guid id)
        {

            List<ResponseDb> responseDb = new List<ResponseDb>();
            foreach (var item in contractorRepository.FindBy<GeneralRequestDB>(x=>x.RecieverId == id))
            {

                ResponseDb responseDb1 = new ResponseDb();

                responseDb1.Id = item.Id;
                responseDb1.RecieverId = item.RecieverId;
                responseDb1.Name = item.Name;
                responseDb1.UserName = item.UserName;
                responseDb1.UserRole = UserRole.Manager;
                responseDb1.SenderId = item.Id;
                responseDb1.Description = item.Message;
                responseDb1.Status = item.Status;
                responseDb.Add(responseDb1);


            }

           return responseDb;



        }

    }
}
