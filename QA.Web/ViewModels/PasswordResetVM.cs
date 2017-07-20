using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.ViewModels
{
    public class PasswordResetVM
    {
        public Guid Code { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}