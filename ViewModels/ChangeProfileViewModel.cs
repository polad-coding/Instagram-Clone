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
        [Remote("IsUserNameExists","Account")]
        public string UserName { get; set; }

        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailExists", controller: "Account")]
        [Required(ErrorMessage = "Cannot be empty!")]

        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(250,ErrorMessage = "Bio can have a max of 250 characters")]
        public string Bio { get; set; }

        [DataType(DataType.Text)]
        public string WebSiteLink { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ProfilePicture { get; set; }
    }
}
