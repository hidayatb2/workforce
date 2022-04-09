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
    public class AdminManager
    {
        private readonly IRepository repository;
        private readonly IEmailService emailService;

        public AdminManager(IRepository repository, IEmailService emailService)
        {
            this.repository = repository;
            this.emailService = emailService;
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
                Salt = AppEncryption.CreateSalt()
            };
            string randomPass = "WF" + random.Next(1, 100000).ToString();
            user.Password = AppEncryption.CreatePasswordHash(randomPass, user.Salt);
            if (repository.IsExist<User>(x => x.UserName == user.UserName)) return -1;

            var list = new List<string>();
            list.Add(user.Email);

            var emailSetting = new MailSetting();
            emailSetting.To = list;
            emailSetting.Subject = "Welcome to WorkForce";
            emailSetting.Body = @$"<h1>Welcome to world of </h1> <a>Please verify you account </a> <br>
                     <p> Your username is {user.UserName} and Password is {randomPass}</p>";
            emailSetting.IsBodyHtml = true;

            emailService.SendMailAsync(emailSetting);

            return repository.AddandSave(user);
        }
    }
}
