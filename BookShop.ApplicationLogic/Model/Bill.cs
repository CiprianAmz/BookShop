using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String CardNumber { get; set; }
        public String ExpirationDate{ get; set; }
        public String CVV { get; set; }
        public int TotalValue { get; set; }
    }
}
