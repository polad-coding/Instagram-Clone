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
        [Remote("IsUserNameExists","Account",ErrorMessage = "The user with the same user name already exists!")]
        public string UserName { get; set; }

        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailExists", controller: "Account")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        [DataType(DataType.Text)]
        public string WebSiteLink { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ProfilePicture { get; set; }
    }
}
