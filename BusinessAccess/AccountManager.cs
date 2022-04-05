using DataAccess;
using Models;

namespace BusinessAccess
{
    public class AccountManager
    {
        private readonly IRepository repository;

        public AccountManager(IRepository repository)
        {
            this.repository = repository;
        }

        public int Add(UserRequest userRequest)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = userRequest.UserName,
                Salt = AppEncryption.CreateSalt(),
                PhoneNo = userRequest.PhoneNo,
                Email = userRequest.Email,
            };
            user.Password = AppEncryption.CreatePasswordHash(userRequest.Password,user.Salt);
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