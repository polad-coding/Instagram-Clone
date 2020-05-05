using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace InstagramClone.ViewModels
{
    public class ChangeProfileViewModel
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Cannot be empty!")]
        [MaxLength(50, ErrorMessage = "Username can have a max of 50 characters")]
        [Remote("IsUserNameExists", "Account", ErrorMessage = "This Username already exists.")]
        public string User_Name { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "Full Name can have a max of 50 characters")]
        public string FullName { get; set; }

        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [EmailAddress(ErrorMessage = "This Email address is incorrect.")]
        [Required(ErrorMessage = "Cannot be empty!")]
        [Remote(action: "IsEmailExists", controller: "Account", ErrorMessage = "This Email already exists.")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(50, ErrorMessage = "Bio can have a max of 50 characters")]
        public string Bio { get; set; }

        [MaxLength(50, ErrorMessage = "Link can have a max of 50 characters")]
        [DataType(DataType.Url)]
        public string WebSiteLink { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ProfilePicture { get; set; }
    }
}
