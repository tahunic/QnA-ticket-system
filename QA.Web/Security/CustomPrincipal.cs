using QA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace QA.Web.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account account;
        public IIdentity Identity { get; set; }


        public CustomPrincipal(Account account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.Username);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(x => this.account.Roles.Contains(x));
        }
    }
}