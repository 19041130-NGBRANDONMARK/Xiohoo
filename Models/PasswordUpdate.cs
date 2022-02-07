using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Lesson05.Models
{
    public partial class PasswordUpdate
    {
        [Required(ErrorMessage = "Password cannot be empty!")]
        [DataType(DataType.Password)]
        [Remote("VerifyCurrentPassword", "Account", ErrorMessage = "Incorrect password!")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Password cannot be empty!")]
        [DataType(DataType.Password)]
        [Remote("VerifyNewPassword", "Account", ErrorMessage = "Cannot reuse password!")]
        //[Not(nameof(CurrentPassword), ErrorMessage = "new Password is not the same")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "New Password cannot be empty!")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Password not confirmed!")]
        public string ConfirmPassword { get; set; }


    }
}
// 19041130 NG BRANDON MARK