using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.ViewModels
{
    public class UserViewModel
    {

        public string Id { get; set; }

        public string Username { get; set; }

        public string Full_Name { get; set; }

        public char? Gender { get; set; }

        public byte[] Profile_Picture_URI { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public string Web_Site_Link { get; set; }

        public bool Current_User_Following { get; set; } = false;
    }
}
