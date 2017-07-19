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
            Account account = am.Login(accountVM.Account.Username, accountVM.Account.Password);

            if (account == null)
            {
                ViewBag.Error = "Account is invalid";
                return View("Login");
            }

            //SessionPersister.Username = accountVM.Account.Username;
            SessionPersister.User = new User
            {
                Id = account.Id,
                Fname = account.Fname,
                Lname = account.Lname,
                Username = account.Username
            };

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            //SessionPersister.Username = string.Empty;
            SessionPersister.User = null;
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