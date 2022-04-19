using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResetPasswordRequest
    {
        [Required(ErrorMessage = "Required!"), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Required!"), DataType(DataType.Password), Compare(nameof(NewPassword), ErrorMessage = "NewPassword and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        public bool IsChecked { get; set; }

        public Guid GUID { get; set; }
    }

    public class ChangePasswordRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
