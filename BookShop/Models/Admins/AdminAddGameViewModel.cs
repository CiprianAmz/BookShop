using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Exceptions;
using BookShop.ApplicationLogic.Model;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace BookShop.Models.Admins
{
    public class AdminAddBookViewModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
    }
}
