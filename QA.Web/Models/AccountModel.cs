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
        private List<Account> accounts = new List<Account>();

        public AccountModel()
        {

        }
        public AccountModel(List<User> users)
        {
            foreach (var user in users)
            {
                accounts.Add(new Account()
                {
                    Username = user.Username,
                    Password = user.Password
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