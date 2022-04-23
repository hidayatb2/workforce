using DataAccess;
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
               // UserName = x.UserName,
                UserRole = UserRole.Manager
            });
        }



        public string SendRequest(RequestDb requestDb)
        {
           GeneralRequestDB generalRequestDB = new GeneralRequestDB()
            {
                Id = new Guid(),
                Message = requestDb.Description,
                SenderUsername = requestDb.SenderUsername,
                RecieverUsername = requestDb.RecieverUsername,
                SenderName = requestDb.SenderName,
                RecieverName = requestDb.RecieverName,
                RecieverId = requestDb.RecieverId,
                SenderId = requestDb.SenderId,
                SenderRole = requestDb.SenderUserRole,
                RecieverRole = requestDb.RecieverUserRole,
                Status = BidStatus.Pending
            };

          var returnValue = contractorRepository.AddandSave<GeneralRequestDB>(generalRequestDB);
            if (returnValue != 0)
            {
                return  "success";
            }
            else
            {
                return "error";
            }
        }


        public IEnumerable<ResponseDb> GetRequests(Guid id)
        {

            return contractorRepository.FindBy<GeneralRequestDB>(x => x.RecieverId == id).Select(x => new ResponseDb
            {
                Id = id,
                Description = x.Message,
                SenderUsername = x.SenderUsername,
                RecieverId = x.RecieverId,
                RecieverUsername = x.RecieverUsername,
                RecieverUserRole = x.RecieverRole,
                SenderUserRole = x.SenderRole,
                SenderId = x.SenderId,
                Status = x.Status

            });

        }

    }
}
