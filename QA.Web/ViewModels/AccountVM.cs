using QA.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QA.Web.ViewModels
{
    public class AccountVM
    {
        public class RegisterDetails
        {
            [Required]
            public string Username { get; set; }
            [Required]
            public string Fname { get; set; }
            [Required]
            public string Lname { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public string PasswordConfirm { get; set; }
        }
        public Account Account { get; set; }
        public RegisterDetails Register { get; set; }

    }
}