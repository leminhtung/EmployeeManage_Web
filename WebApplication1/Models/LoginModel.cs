using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "LoginID can note be blank")]
        public string AdminId { set; get; }
        [Required(ErrorMessage = "Password can note be blank")]
        public string Password { set; get; }
    }
}