﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Users
{
    public class UserAddRatingViewModel
    {
        public Guid BookID { get; set; }
        public float Rate { get; set; }
    }
}