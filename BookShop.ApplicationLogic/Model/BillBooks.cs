using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class BillBooks
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid BillId { get; set; }
    }
}
