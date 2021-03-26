using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class ViewBills
    {
        public IEnumerable<Bill> Bills { get; set; }
    }
}
