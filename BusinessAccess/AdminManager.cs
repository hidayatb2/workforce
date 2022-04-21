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
                UserName = signupRequest.Email.Split('@')[0].ToLower(),
                Email = signupRequest.Email,
                PhoneNo = signupRequest.PhoneNo,
                UserStatus = UserStatus.Inactive,
                UserRole = signupRequest.UserRole,
                Salt = AppEncryption.CreateSalt()
            };
            string randomPass = "WF" + random.Next(1, 100000).ToString();
            user.Password = AppEncryption.CreatePasswordHash(randomPass, user.Salt);
            if (repository.IsExist<User>(x => x.Email == user.Email)) return -1;
            if (repository.IsExist<User>(x => x.PhoneNo == user.PhoneNo)) return -2;
            var list = new List<string>();
            list.Add(user.Email);

            var emailSetting = new MailSetting();
            emailSetting.To = list;
            emailSetting.Subject = "Welcome to WorkForce";
            emailSetting.Body = @$"<h1>Welcome to World of WorkForce</h1>
                                  <div> Your Username is {user.UserName} and Password is {randomPass}.</div>
                                  <a href="" >Please Verify Your Account</a>
                                  <div></div>
                                  <h5> Thank You,</h5>
                                  <h5> Team WorkForce</h5>";
            emailSetting.IsBodyHtml = true;

            emailService.SendMailAsync(emailSetting);

            return repository.AddandSave(user);
        }

        public IEnumerable<ContactUsResponse> GetAllMessages()
        {
            List<ContactUsResponse> contactUsResponses = new List<ContactUsResponse>();

            foreach (var item in repository.GetAll<ContactUs>())
            {
                ContactUsResponse response = new ContactUsResponse();
                 response.Email = item.Email;
                 response.Name = item.Name;
                 response.PhoneNo = item.PhoneNo;
                response.Message = item.Message;
                contactUsResponses.Add(response);
            };

            return contactUsResponses;

        }

        public IEnumerable<TestimonialResponse> GetTestimonial()
        {
            List<TestimonialResponse> testimonialResponses = new List<TestimonialResponse>();
            foreach (var item in repository.GetAll<Testimonial>())
            {
                TestimonialResponse response = new TestimonialResponse();
                response.Id = item.Id;
                response.Name = item.Name;
                response.FeedbackMessage= item.FeedbackMessage;
                response.Status = FeedbackStatus.Hidden;
                response.UserRole = item.UserRole;
                testimonialResponses.Add(response);
            }
            return testimonialResponses;
        }


        public IEnumerable<GeneralResponse> GetRoles(UserRole role)
        {
            if (role == UserRole.Manager)
            {
                return repository.GetAll<Contractor>().Select(x => new GeneralResponse
                {
                    Id = x.Id,
                    Name = x.Name
                });
            }
            else if(role == UserRole.Labour)
            {
                return repository.GetAll<Manager>().Select(x => new GeneralResponse
                {
                    Id = x.Id,
                    Name = x.Name
                });
            }

            else
            {
                return null;
            }
            

        }


        public int ChangeUserStatus(Guid id)
        {
            var userInActivity = repository.GetById<User>(id);
            if (userInActivity.UserStatus == UserStatus.Inactive)
            {
                userInActivity.UserStatus = UserStatus.Active;
                return repository.UpdateAndSave(userInActivity);
            }

            else
            {
                userInActivity.UserStatus = UserStatus.Inactive;
                return repository.UpdateAndSave(userInActivity);
            }
        }



    }
}
