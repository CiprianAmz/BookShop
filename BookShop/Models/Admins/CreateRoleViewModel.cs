﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models.Admins
{
    public class CreateRoleViewModel
    {
        [Required]
        public String roleName { get; set; }
    }
}
