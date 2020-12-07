using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class Rating
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public float Rate { get; set; }
        public Guid BookId { get; internal set; }
       
    }
}
