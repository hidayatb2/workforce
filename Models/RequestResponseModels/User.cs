using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserRequest
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }


        [RegularExpression("[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$", ErrorMessage = "Please enter a valid format for email"), MinLength(6), MaxLength(30)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "PhoneNo is required")]
        public string PhoneNo { get; set; }

    }

    public class UserResponse:UserRequest
    {

    }

    public class SignupRequest:UserRequest
    {
        public UserRole UserRole { get; set; }
    }

    public class LoginRequest
    {
        [Required(ErrorMessage ="UserName id Required!")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Password id Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        public bool RememberMe { get; set; }
    }

    public class LoginResponse : UserRequest
    {
        public bool HasError { get; set; }

        public UserRole UserRole { get; set; }


        public UserStatus UserStatus { get; set; }
    }
}