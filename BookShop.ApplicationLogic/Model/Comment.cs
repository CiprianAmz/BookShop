using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.ApplicationLogic.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String Comm { get; set; }
        public Guid BookId { get; set; }
        public string Username { get; set; }
    }
}
