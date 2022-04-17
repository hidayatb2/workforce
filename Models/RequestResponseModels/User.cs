
﻿//using Newtonsoft.Json;

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
        public Guid CreatedBy { get; set; }


        public DateTime CreatedOn { get; set; }


        public UserRole UserRole { get; set; }


        public UserStatus UserStatus { get; set; }
    }


    public class UserCompact : UserResponse
    {
        public string Name { get; set; }


        public Gender Gender { get; set; }


        public string Address { get; set; }


        public string Bank { get; set; }


        public string AccountNo { get; set; }


        public string IFSC { get; set; }


        public string JobProfile { get; set; }


        public string Experience { get; set; }


        public WagesType WagesType { get; set; }


        public float Wages { get; set; }


        public string Discription { get; set; }


    }

    public class LabourResponse :UserResponse
    {
     
       

        public string AdhaarNo { get; set; }


        public string Address1 { get; set; }


        public string Address2 { get; set; }


        public string PhoneNo2 { get; set; }


        public string Bank { get; set; }


        public string AccountNo { get; set; }


        public string IFSC { get; set; }


        public bool IsSkilled { get; set; }
    }


    public class ManagerResponse :UserResponse
    {

    }

    public class SignupRequest:UserRequest
    {

        [Required(ErrorMessage = "DOB Required")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/mm/yyy}", ApplyFormatInEditMode = true)]
        //[RegularExpression("^(0[1 - 9] | 1[012])[- /.](0[1 - 9] |[12][0 - 9] | 3[01])[- /.](19 | 20)\\d\\d$", ErrorMessage="User is Below 18 or Above 60" )]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage ="Please Enter Role")]
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

    public class SkillRequest
    {
        public Guid LabourId { get; set; }


        public string Name { get; set; }


        //public Guid ManagerId { get; set; }


        public string JobProfile { get; set; }


        public string Experience { get; set; }


        public WagesType WagesType { get; set; }


        public float Wages { get; set; }


        public string Discription { get; set; }
    }

    public class SkillResponse : SkillRequest
    {

    }
}