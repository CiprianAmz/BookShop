using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class UserAddCommentViewModel
    {
        public Guid BookID { get; set; }
        public String Comm { get; set; }

    }
}
