using BookShop.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class UserMainBookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public float Rating { get; set; }
        public string Category { get; set; }
    }
}
