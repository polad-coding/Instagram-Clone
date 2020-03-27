using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.ViewModels
{
    public class CaptionViewModel
    {
        public int Caption_Id { get; set; }

        public string Author_Id { get; set; }

        public string Username { get; set; }

        public string Caption_Text { get; set; }

        public DateTime Creation_Time { get; set; }

        public byte[] Profile_Picture_URI { get; set; }

    }
}
