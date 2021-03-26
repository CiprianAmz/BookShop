using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class ViewCart
    {
        public IEnumerable<CartItem> cartItems { get; set; }
        public IEnumerable<Book> Books { get; set; } 

        public float Value { get; set; }

    }
}
