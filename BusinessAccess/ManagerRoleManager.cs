using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class ManagerRoleManager
    {

        readonly ManagerRepository managerRepository;

        public ManagerRoleManager(ManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }



        public IEnumerable<GeneralResponse> GetContractors()
        {
           return  managerRepository.GetAll<Contractor>().Select(x => new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                UserName = x.UserName,
                Address = x.Address,
                UserRole = UserRole.Contractor

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

            var returnValue = managerRepository.AddandSave<GeneralRequestDB>(generalRequestDB);
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

          return managerRepository.FindBy<GeneralRequestDB>(x => x.RecieverId == id).Select(x => new ResponseDb
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

        public IEnumerable<UserResponse> GetAllLabours()
        {
            List<UserResponse> users = new List<UserResponse>();

            foreach (var item in managerRepository.GetAll<User>())
            {
                if (item.UserRole == UserRole.Labour)
                {
                    UserResponse response = new UserResponse();
                    response.Id = item.Id;
                    response.UserName = item.UserName;
                    response.Email = item.Email;
                    response.PhoneNo = item.PhoneNo;

                    users.Add(response);
                };
            }
            return users;
        }


        public void Attendance()
        {


        }


    }
}
