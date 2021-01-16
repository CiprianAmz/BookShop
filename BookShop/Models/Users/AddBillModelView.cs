using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.ApplicationLogic.Model;

namespace BookShop.Models.Users
{
    public class AddBillModelView
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String CardNumber { get; set; }
        public String ExpirationDate { get; set; }
        public String CVV { get; set; }
        public int TotalValue { get; set; }

    }
}
