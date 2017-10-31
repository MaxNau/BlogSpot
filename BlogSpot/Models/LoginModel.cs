using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSpot.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="User name is required")]
        [Display(Name = "User name (*)")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="password is required")]
        [Display(Name = "Password (*)")]
        public string Password { get; set; }
    }
}