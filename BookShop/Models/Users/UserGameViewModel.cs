using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.ApplicationLogic.Model;
namespace BookShop.Models.Users
{
    public class UserBookViewModel
    {
        public IEnumerable<Book> Books { get; set; }

    }
}
