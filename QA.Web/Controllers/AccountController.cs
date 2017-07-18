using QA.Model.Models;
using QA.Service;
using QA.Web.Models;
using QA.Web.Security;
using QA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.Controllers
{
    public class AccountController : Controller
    { 
        private readonly IUserService userService;
        private readonly IStudentService studentService;

        public AccountController(IUserService userService, IStudentService studentService)
        {
            this.userService = userService;
            this.studentService = studentService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TryLogin(AccountVM accountVM)
        {
            List<User> users = userService.GetAll().ToList();
            AccountModel am = new AccountModel(users);
            if (string.IsNullOrEmpty(accountVM.Account.Username) || string.IsNullOrEmpty(accountVM.Account.Password) ||
                am.Login(accountVM.Account.Username, accountVM.Account.Password) == null)
            {
                ViewBag.Error = "Account is invalid";
                return View("Login");
            }

            SessionPersister.username = accountVM.Account.Username;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            SessionPersister.username = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(AccountVM accountVM)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Login");

            Student s = new Student()
            {
                IsDeleted = false,
                IndexNumber = "IB140072",
                User = new User
                {
                    IsDeleted = false,
                    CityId = 4,
                    Email = accountVM.Register.Email,
                    Fname = accountVM.Register.Fname,
                    Lname = accountVM.Register.Lname,
                    Password = accountVM.Register.Password,
                    Username = accountVM.Register.Username
                }
            };

            studentService.Create(s);
            studentService.Save();

            Account a = new Account() { Username = accountVM.Register.Username, Password = accountVM.Register.Password };
            AccountVM avm = new AccountVM() { Account = a };

            return TryLogin(avm);
        }
    }
}