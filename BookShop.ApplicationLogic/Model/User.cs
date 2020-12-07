using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
    }
}
