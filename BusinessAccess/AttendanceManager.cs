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
    public class AttendanceManager
    {
        private readonly AttendanceRepository repository;

        public AttendanceManager(AttendanceRepository repository)
        {
            this.repository = repository;
        }


        public IEnumerable<UserResponse> GetAllLabours()
        {
            List<UserResponse> users = new List<UserResponse>();

            foreach (var item in repository.GetAll<User>())
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
    }
}
