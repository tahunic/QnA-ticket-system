using QA.Model.Models;
using QA.Service;
using QA.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.Models
{
    public class AccountModel
    {
        //private MyContext _ctx = new MyContext();
        private static List<Account> accounts = new List<Account>();

        public AccountModel()
        {

        }
        public AccountModel(List<User> users)
        {
            foreach (var user in users)
            {
                accounts.Add(new Account()
                {
                    Id = user.Id,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Username = user.Username,
                    Password = user.Password,
                    Roles = user.UserRoles.Select(r=>r.Role.Name).ToArray()
                });
            }
        }
        
        
        public Account Find(string username)
        {
            return accounts.FirstOrDefault(x => x.Username.Equals(username));
        }

        public Account Login(string username, string password)
        {
            return accounts.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
        }
    }
}