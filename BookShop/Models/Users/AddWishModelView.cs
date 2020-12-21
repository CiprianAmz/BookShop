using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.ApplicationLogic.Model;

namespace BookShop.Models.Users
{
    public class AddWishModelView
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

    }
}
