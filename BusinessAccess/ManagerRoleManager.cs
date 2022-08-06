using DataAccess;
using Microsoft.AspNetCore.Mvc;
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
            return managerRepository.GetAll<Contractor>().IncludeNav(z => z.User).Select(x => new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                UserName = x.User.UserName,
                Address = x.Address,
                UserRole = UserRole.Contractor

            });
        }


        public IEnumerable<GeneralResponse> GetLabours()
        {
            return managerRepository.GetAll<Labour>().IncludeNav(z => z.User).Select(x => new GeneralResponse
            {
                Id = x.Id,
                Name = x.Name,
                UserName = x.User.UserName,
                Address = x.Address,
                UserRole = UserRole.Labour

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

        public IEnumerable<UserResponse> UnassignedLabours()
        {
            List<UserResponse> users = new List<UserResponse>();

            foreach (var item in managerRepository.GetAll<User>().Where(x => x.Labour.ManagerId == null))
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

        public IEnumerable<UserResponse> AssignedLabour(Guid id)
        {
            List<UserResponse> users = new List<UserResponse>();

            foreach (var item in managerRepository.FindBy<User>(x => x.Labour.ManagerId == id))
            {
                UserResponse response = new UserResponse();
                response.Id = item.Id;
                response.UserName = item.UserName;
                response.Email = item.Email;
                response.PhoneNo = item.PhoneNo;

                users.Add(response);

            };
            return users;
        }


        public int TimeIn(Guid labourId)
        {
            DateTime dt= DateTime.Now.Date;  
            var UserId = managerRepository.FindBy<Labour>(x => x.Id == labourId).FirstOrDefault();
            var checkAttendance = managerRepository.FindBy<Attendance>(x => x.LabourId == UserId.Id && x.Date == dt).SingleOrDefault();
            if (checkAttendance == null)
            {
                Attendance attendance = new Attendance();
                attendance.LabourId = labourId;
                attendance.AttendaceId = Guid.NewGuid();
                attendance.Date = DateTime.Now.Date;
                attendance.TimeIn = DateTime.Now;
                return managerRepository.AddandSave(attendance);
            }
            else return 0;
           
       

           

        }
    

        public int TimeOut(Guid labourId)
        
        {
            var UserId = managerRepository.FindBy<Labour>(x=>x.Id == labourId).FirstOrDefault();
            var Attendancee = managerRepository.FindBy<Attendance>(x => x.LabourId == UserId.Id).FirstOrDefault();
            Guid id = Attendancee.AttendaceId;
            var Out = managerRepository.FindBy<Attendance>(x => x.AttendaceId == id).SingleOrDefault();
            Attendancee.TimeOut = DateTime.Now;
            return managerRepository.UpdateAndSave(Attendancee);
        }

        public IEnumerable<UserAttendanceResponse> GetAttendance(Guid labourId)
        {
            //var UserId = managerRepository.FindBy<Labour>(x => x.Id == labourId).FirstOrDefault();
           // var Attendancee = managerRepository.FindBy<Attendance>(x => x.LabourId == labourId).FirstOrDefault();
            var res = managerRepository.FindBy<Attendance>(x => x.LabourId == labourId).Select(x => new UserAttendanceResponse
            {
                Id=x.AttendaceId,
                Date=x.Date,
                In=x.TimeIn,
                Out=x.TimeOut,
                LabourId=x.LabourId,
                TotalWorkingHours = 10-12, /*x.TimeIn.Hour-DateTime.Now.Hour,*/
            });
            return res;
        }



        public string SendLabourRequest(RequestDb requestDb)
        {
            GeneralRequestDB generalRequestDB = new GeneralRequestDB()
            {
                Id = new Guid(),
                SenderUsername = requestDb.SenderUsername,
                RecieverUsername = requestDb.RecieverUsername,
                SenderName = requestDb.SenderName,
                RecieverName = requestDb.RecieverName,
                RecieverId = requestDb.RecieverId,
                SenderId = requestDb.SenderId,
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

        public IEnumerable<ResponseDb> GetLabourRequests(Guid id)
        {

            return managerRepository.FindBy<GeneralRequestDB>(x => x.RecieverId == id).Select(x => new ResponseDb
            {
                Id = id,
                SenderUsername = x.SenderUsername,
                RecieverId = x.RecieverId,
                RecieverUsername = x.RecieverUsername,
                SenderId = x.SenderId,
            });

        }
    }
}
