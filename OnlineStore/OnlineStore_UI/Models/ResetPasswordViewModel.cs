﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Models
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string Guid { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
