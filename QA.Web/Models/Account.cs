using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}