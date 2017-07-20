using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.ViewModels
{
    public class PasswordChangeVM
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}