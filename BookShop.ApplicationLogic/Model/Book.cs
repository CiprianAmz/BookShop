using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace BookShop.ApplicationLogic.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public Admin Admin { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<Rating> Rating { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        public string ImageFile { get;set; }

    }
}
