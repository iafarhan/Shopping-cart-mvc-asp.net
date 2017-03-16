using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Login
    {
//        [Required(ErrorMessage = "Please enter your username")]
        public string username { set; get; }

//        [Required(ErrorMessage = "PLease enter your password.")]
        public string password { set; get; }
    }
}