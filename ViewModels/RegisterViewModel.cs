using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailExists", controller: "Account",ErrorMessage = "This Email address already exists in our database.")]
        public string Email { get; set; }

        public string Full_Name { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        [Remote("IsUserNameExists", "Account",ErrorMessage = "This Username already exists in our database.")]
        public string User_Name { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Minimum password length must be 6 characters.")]
        [MinLength(6,ErrorMessage = "Minimum password length must be 6 characters.")]
        public string Password { get; set; }

    }
}
