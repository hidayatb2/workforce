using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class LabourManager
    {

        private readonly LabourRepository repository;


        public LabourManager(LabourRepository repository)
        {
            this.repository = repository;
        }




        public IEnumerable<GeneralResponse> GetManagers()
        {
            return repository.GetAll<Manager>().IncludeNav(x => x.User).Select(x => new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                UserName = x.User.UserName,
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

            var returnValue = repository.AddandSave<GeneralRequestDB>(generalRequestDB);
            if (returnValue != 0)
            {
                return "success";
            }
            else
            {
                return "error";
            }
        }



        public IEnumerable<ResponseDb> GetRequests(Guid id)
        {

            return repository.FindBy<GeneralRequestDB>(x => x.RecieverId == id).Select(x => new ResponseDb
            {
                Id = x.Id,
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


        public IEnumerable<ResponseDb> GetColabRequests(Guid id)
        {

            return repository.FindBy<GeneralRequestDB>(x => x.RecieverId == id && x.Message == null).Select(x => new ResponseDb
            {
                Id = x.Id,
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



        public int DeletebyId(Guid id)
        {
             var deletedItem = repository.GetById<GeneralRequestDB>(id);
             return repository.Delete(deletedItem);
        }


        public int ApproveColabRequest(Guid senderId,Guid currentUserId)
        {
          var lbrUser= repository.GetById<Labour>(currentUserId);
            lbrUser.ManagerId = senderId;
            
           return repository.UpdateAndSave(lbrUser);
        }



    }
}
