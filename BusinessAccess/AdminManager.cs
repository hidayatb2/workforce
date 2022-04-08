using DataAccess;
using Models;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class AdminManager
    {
        private readonly IRepository repository;

        public AdminManager(IRepository repository)
        {
            this.repository = repository;
        }

        public int CreateUser(SignupRequest signupRequest)
        {
            Random random = new Random();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = signupRequest.Email.Split('@')[0],
                Email = signupRequest.Email,
                PhoneNo = signupRequest.PhoneNo,
                UserStatus = UserStatus.Active,
                UserRole = signupRequest.UserRole,
                //Salt = AppEncryption.CreateSalt(),
                Password = "WF" + random.Next(1,1000000).ToString(),
            };
            //user.Password = AppEncryption.CreatePasswordHash(user.Password, user.Salt);
            if (repository.IsExist<User>(x => x.UserName == signupRequest.UserName)) return -1;
            return repository.AddandSave(user);
        }
    }
}
