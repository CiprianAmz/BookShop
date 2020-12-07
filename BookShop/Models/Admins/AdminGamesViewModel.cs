using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Exceptions;
using BookShop.ApplicationLogic.Model;

namespace BookShop.Models.Admins
{
    public class AdminBooksViewModel
    {
        public Admin Admin { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
