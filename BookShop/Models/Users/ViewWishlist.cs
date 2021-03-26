using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class ViewWishlist
    {
        public IEnumerable<ShoppingCart> Orders { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
