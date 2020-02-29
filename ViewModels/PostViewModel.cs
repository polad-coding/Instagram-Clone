using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string IUser_Id { get; set; }

        public int? Number_Of_Likes { get; set; } = 0;

        public int? Number_Of_Captions { get; set; } = 0;

        public byte[] Picture { get; set; }

    }
}
