using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class Admin
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String Passord { get; set; }
        public String Email { get; set; }

    }
}
