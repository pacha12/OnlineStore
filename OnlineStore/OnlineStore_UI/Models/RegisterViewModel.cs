using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
