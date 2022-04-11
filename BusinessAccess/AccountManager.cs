using DataAccess;
using Models;
using SharedLibrary;

namespace BusinessAccess
{
    public class AccountManager
    {
        private readonly IRepository repository;
        private readonly IEmailService emailService;

        public AccountManager(IRepository repository, IEmailService emailService)
        {
            this.repository = repository;
            this.emailService = emailService;
        }

        
        //public IEnumerable<User> FindBy(string searchString)
        //{
            
        //    return repository.FindBy<User>(x => x.UserName == searchString || x.Email == searchString || x.PhoneNo == searchString,
           
        //}

        public IEnumerable<UserResponse> SearchUserBy(string searchString)
        {
          List<UserResponse> userResponses = new List<UserResponse>();
            
            foreach (var item in repository.FindBy<User>(x => x.UserName.StartsWith(searchString) || x.Email.StartsWith(searchString) || x.PhoneNo.StartsWith(searchString)))
            {
                UserResponse response = new UserResponse();
                response.UserName = item.UserName;
                response.Email = item.Email;
                response.PhoneNo = item.PhoneNo;
                response.PhoneNo = item.PhoneNo;
                response.CreatedBy = item.CreatedBy;
                response.CreatedOn = item.CreatedOn;
                response.UserRole = item.UserRole;
                response.UserStatus = item.UserStatus;
                userResponses.Add(response);
            };

             return userResponses;
        }



        public IEnumerable<UserResponse> GetAllUsers( )
        {
            List<UserResponse> userResponses = new List<UserResponse>();

            foreach (var item in repository.GetAllUsers<User>())
            {
                UserResponse response = new UserResponse();
                response.UserName = item.UserName;
                response.Email = item.Email;
                response.PhoneNo = item.PhoneNo;
                response.PhoneNo = item.PhoneNo;
                response.CreatedBy = item.CreatedBy;
                response.CreatedOn = item.CreatedOn;
                response.UserRole = item.UserRole;
                response.UserStatus = item.UserStatus;
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
                UserStatus = UserStatus.Inactive,
                UserRole = UserRole.Labour
            };
            user.Password = AppEncryption.CreatePasswordHash(signupRequest.Password,user.Salt);
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
           var dbUser= repository.FindBy<User>(x=>x.UserName == loginRequest.UserName).FirstOrDefault();
            if (dbUser != null)
            {
                if (dbUser.Password.Equals(AppEncryption.CreatePasswordHash(loginRequest.Password, dbUser.Salt)))
                {
                    loginResponse.Id = dbUser.Id;
                    loginResponse.UserName = dbUser.UserName;
                    loginResponse.Email = dbUser.Email;
                    loginResponse.PhoneNo = dbUser.PhoneNo;
                    loginResponse.UserRole = dbUser.UserRole;
                    loginResponse.UserStatus= dbUser.UserStatus;
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
                loginResponse.HasError= true;
                return loginResponse;
            }
        }


    }
}