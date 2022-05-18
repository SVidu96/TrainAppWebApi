﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models
{
    public class UserLogin
    {
        [Key]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
