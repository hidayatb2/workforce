using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Models;
using SharedLibrary;
using System.Text;

namespace BusinessAccess
{
    public class AccountManager
    {
        private readonly AccountRepository repository;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;

        public AccountManager(AccountRepository repository, IEmailService emailService,IMapper mapper)
        {
            this.repository = repository;
            this.emailService = emailService;
            this.mapper = mapper;
        }


        public IEnumerable<UserResponse> SearchUserBy(string searchString)
        {
            List<UserResponse> userResponses = new List<UserResponse>();

            foreach (var item in repository.FindBy<User>(x => x.UserName.StartsWith(searchString) || x.Email.StartsWith(searchString) || x.PhoneNo.StartsWith(searchString)))
            {
                UserResponse response = new UserResponse();
                response.Id = item.Id;
                response.UserName = item.UserName;
                response.Email = item.Email;
                response.PhoneNo = item.PhoneNo;
                response.CreatedBy = item.CreatedBy;
                response.CreatedOn = item.CreatedOn;
                response.UserRole = item.UserRole;
                response.UserStatus = item.UserStatus;
                userResponses.Add(response);
            };

            return userResponses;
        }

        public AdminResponse GetAdminById(Guid id)
        {
            var admin = repository.FindBy<User>(x => x.Id == id).FirstOrDefault();
            AdminResponse admres = new AdminResponse()
            {
                Id = admin.Id,
                UserName = admin.UserName,
                Email = admin.Email,
                PhoneNo = admin.PhoneNo,
                ImagePath = admin.ImagePath,
                UserStatus = admin.UserStatus,
            };

            return admres;
        }


        public int UpdateAdmin(AdminRequest adminRequest, string webRootPath)
        {
            var user= repository.GetById<User>(adminRequest.Id);
            user.Name = adminRequest.UserName;


            //User user = new User()
            //{
            //    PhoneNo = adminRequest.PhoneNo,
            //    ImagePath = adminRequest.ImagePath,
            //};
            //if (repository.FindBy<User>(x => x.Email == adminRequest.Email && x.Id == adminRequest.Id).Any()) user.Email = adminRequest.Email; else
            //{
            //    if (repository.FindBy<User>(x => x.Email == adminRequest.Email).Any()) return -1;
            //}
            //if (repository.FindBy<User>(x => x.UserName == adminRequest.UserName && x.Id == adminRequest.Id).Any()) user.UserName = adminRequest.UserName; else
            //{
            //    if (repository.FindBy<User>(x => x.UserName == adminRequest.UserName).Any()) return -2;
            //}
            //var uzer = mapper.Map<AdminRequest, User>(adminRequest);

            if (adminRequest.File != null)
            {
                if (user.ImagePath != webRootPath)
                {
                    FileManager.DeleteFile(webRootPath, user.ImagePath);
                }

                user.ImagePath = FileManager.SaveFile(adminRequest.File, webRootPath);
            }
            return repository.UpdateAndSave(user);

        }

       

        public ProfileResponse GetUserById(Guid id, string userRole)
        {
            return repository.GetProfile(id, userRole);
        }


        public IEnumerable<UserResponse> GetAllUsers()
        {
            List<UserResponse> userResponses = new List<UserResponse>();

            foreach (var item in repository.GetAll<User>())
            {
                UserResponse response = new UserResponse();
                response.Id = item.Id;
                response.UserName = item.UserName;
                response.Email = item.Email;
                response.PhoneNo = item.PhoneNo;
                response.CreatedBy = item.CreatedBy;
                response.CreatedOn = item.CreatedOn;
                response.UserRole = item.UserRole;
                response.UserStatus = item.UserStatus;
                response.Password = item.Password;
                response.DOB = item.DOB;
                response.salt = item.Salt;

                
                userResponses.Add(response);
            };

            return userResponses;
        }
        public int Add(SignupRequest signupRequest)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = signupRequest.UserName.ToLower(),
                Salt = AppEncryption.CreateSalt(),
                PhoneNo = signupRequest.PhoneNo,
                Email = signupRequest.Email,
                UserStatus = UserStatus.Active,
                UserRole = signupRequest.UserRole,
            };
            if (signupRequest.UserRole == UserRole.Labour)
            {
                user.Labour = new Labour();
               // user.Labour.ManagerId = Guid.Empty;
                user.Labour.Id = user.Id;
            }
            else if (signupRequest.UserRole == UserRole.Manager)
            {
                user.Manager = new Manager();
                //user.Manager.ContractorId=Guid.Empty;
                user.Manager.Id = user.Id;
                //user.Manager.UserName=signupRequest.UserName;
            }
            else if (signupRequest.UserRole == UserRole.Contractor)
            {
                user.Contractor = new Contractor();
                user.Contractor.Id = user.Id;
               // user.Contractor.UserName = signupRequest.UserName;
            }
            else if (signupRequest.UserRole == UserRole.Customer)
            {
                user.Customer = new Customer();
                user.Customer.Id = user.Id;
            }

            user.Password = AppEncryption.CreatePasswordHash(signupRequest.Password, user.Salt);
            if (repository.IsExist<User>(x => x.UserName == user.UserName)) return -1;
            var list = new List<string>();
            list.Add(user.Email);

            var emailSetting = new MailSetting();
            emailSetting.To = list;
            emailSetting.Subject = "Welcome to WorkForce";
            emailSetting.Body = @$"<h1>Welcome to world of Work Force </h1>  <br>
                                    <p>Your account has been created successfully</p>";
            emailSetting.IsBodyHtml = true;
            emailService.SendMailAsync(emailSetting);
            return repository.AddandSave(user);
        }
        public LoginResponse LogIn(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            var dbUser = repository.FindBy<User>(x => x.UserName == loginRequest.UserName).FirstOrDefault();
            if (dbUser != null)
            {
                if (dbUser.Password.Equals(AppEncryption.CreatePasswordHash(loginRequest.Password, dbUser.Salt)))
                {
                    loginResponse.Id = dbUser.Id;
                    loginResponse.UserName = dbUser.UserName;
                    loginResponse.Email = dbUser.Email;
                    loginResponse.PhoneNo = dbUser.PhoneNo;
                    loginResponse.UserRole = dbUser.UserRole;
                    loginResponse.UserStatus = dbUser.UserStatus;
                    loginResponse.ImagePath = dbUser.ImagePath;
                    return loginResponse;
                }
                else
                {
                    loginResponse.HasError = true;
                    return loginResponse;
                }
            }
            else
            {
                loginResponse.HasError = true;
                return loginResponse;
            }
        }

        public string ForgetPassword(ForgotPasswordRequest email, string link, [FromServices] IEmailService emailService)
        {
            User? user = repository.FindBy<User>(x => x.Email == email.Email).FirstOrDefault();
            if (user != null)
            {
                Guid guid = Guid.NewGuid();
                user.ResetCode = guid.ToString();
                link += guid;
                var value = repository.UpdateAndSave(user);
                if (value >= 1)
                {
                    var x = SendResetEmail(user, link);
                    return "success";
                }
            }
            return "NotExist";
        }
        public async Task SendResetEmail(User request, string link)
        {
            var email = new List<string>();
            email.Add(request.Email);
            var emailSetting = new MailSetting();
            emailSetting.To = email;
            emailSetting.Subject = "Reset Password (WorkForce)";

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("Please Click on the following link to reset your password <br>");
            mailBody.AppendFormat(link);
            emailSetting.Body = mailBody.ToString();
            emailSetting.IsBodyHtml = true;
            emailService?.SendMailAsync(emailSetting);
        }

        public User ResetPassword(ResetPasswordRequest resetPassword)
        {
            User user = repository.FindBy<User>(x => x.ResetCode == resetPassword.GUID.ToString()).FirstOrDefault();
            if (user != null)
            {
                user.Salt = AppEncryption.CreateSalt();
                user.Password = AppEncryption.CreatePasswordHash(resetPassword.NewPassword, user.Salt);
                user.ResetCode = null;
                repository.UpdateAndSave(user);
                return user;
            }
            return null;
        }


        public string ChangePassword(ChangePasswordRequest changePassword)
        {
            User userAccount = repository.GetById<User>(changePassword.Id);
            if (userAccount != null)
            {
                string dbSalt = userAccount.Salt;
                string dbPassword = userAccount.Password;
                string oldPass = AppEncryption.CreatePasswordHash(changePassword.OldPassword, dbSalt);
                if (oldPass.Equals(dbPassword))
                {
                    userAccount.Salt = AppEncryption.CreateSalt();
                    userAccount.Password = AppEncryption.CreatePasswordHash(changePassword.NewPassword, userAccount.Salt);
                    repository.UpdateAndSave(userAccount);
                    return "success";
                }
                else
                {
                    return "Old Password is not Correct";
                }
            }
            else
            {
                return "UserName is not Correct";
            }
        }

        public int UpdateUser(ProfileResponse profileResponse,string webRootPath, string userRole)
        {
            var user = repository.GetById<User>(profileResponse.Id);

            if (repository.FindBy<User>(x => x.Id == profileResponse.Id && x.Email == profileResponse.Email).Any())
            {
                user.Email = profileResponse.Email;
            }
            else if (repository.FindBy<User>(x => x.Email == profileResponse.Email).Any()) return -1;


          

            if(userRole=="Labour")
            {
                var lbr = repository.UpdateLabourDetails(profileResponse);
            }
            else if (userRole == "Manager")
            {
                var lbr = repository.UpdateManagerDetails(profileResponse);
            }
            else if (userRole == "Contractor")
            {
                var lbr = repository.UpdateContractorDetails(profileResponse);
            }
            //else if (userRole == "Customer")
            //{
            //    var lbr = repository.UpdateCustomerDetails(profileResponse);
            //}

            return repository.UpdateAndSave(user);
        }
    }
}
