using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class SearchedListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public String searchedWord { get; set; }
    }
}
