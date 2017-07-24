using QA.Model.Models;
using QA.Service;
using QA.Web.Helper;
using QA.Web.Models;
using QA.Web.Security;
using QA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.Controllers
{
    public class AccountController : Controller
    { 
        private readonly IUserService userService;
        private readonly IStudentService studentService;
        private readonly IUserPasswordForgetService userPasswordForgetService;
        private WebAPIHelper tokenAPIservice = new WebAPIHelper("api/token");

        public AccountController(IUserService userService, IStudentService studentService, IUserPasswordForgetService userPasswordForgetService)
        {
            this.userService = userService;
            this.studentService = studentService;
            this.userPasswordForgetService = userPasswordForgetService;
        }

        public ActionResult Login()
        {
            if (HttpContext.Request.IsAjaxRequest())
            {
                return View();
            }
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
            
            SessionPersister.User = new User
            {
                Id = account.Id,
                Fname = account.Fname,
                Lname = account.Lname,
                Username = account.Username
            };

            HttpResponseMessage response = tokenAPIservice.GetActionResponse("GetToken", account.Username + "/" + account.Password);
            if (response.IsSuccessStatusCode)
            {
                SessionPersister.Jwt = response.Content.ReadAsAsync<string>().Result;
            }

            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Logout()
        {
            //SessionPersister.Username = string.Empty;
            SessionPersister.User = null;
            SessionPersister.Jwt = string.Empty;
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

        public ActionResult ForgotPassword()
        {
            ForgotPasswordVM model = new ForgotPasswordVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordVM model)
        {
            User user = userService.GetByEmail(model.Email);

            if(user == null)
            {
                ViewBag.Error = "User with this email does not exist.";
                return View(model);
            }
            else
            {
                UserPasswordForget currentRequest = userPasswordForgetService.GetByUser(user.Id).OrderByDescending(p => p.CreatedOn).FirstOrDefault();

                if (currentRequest != null)
                {
                    if (currentRequest.CreatedOn.AddMinutes(20) > DateTime.Now)
                    {
                        ViewBag.Error = "You already asked for a code, you can get a new one in " + ((currentRequest.CreatedOn.AddMinutes(20) - DateTime.Now).Minutes + 1).ToString() + " minutes";
                        return View(model);
                    }
                }

                UserPasswordForget forgetPassword = new UserPasswordForget()
                {
                    UserId = user.Id,
                    CreatedOn = DateTime.Now,
                    Code = Guid.NewGuid()
                };

                userPasswordForgetService.Create(forgetPassword);
                userPasswordForgetService.Save();

                string subject = "Password reset";
                string body = "Reset password by clicking on a link(it will expire in 20 minutes): " + System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~/") + "Account/PasswordChange?guid=" + forgetPassword.Code.ToString();
                EmailSender.SendEmail(model.Email, subject, body);

                ViewBag.Success = "Email has been sent.";

                return View(model);
            }
        }

        public ActionResult PasswordChange(Guid guid)
        {
            UserPasswordForget request = userPasswordForgetService.GetByCode(guid);

            if(request == null)
            {
                return RedirectToAction("ExpiredPasswordCode");
            }
            else
            {
                if (request.CreatedOn.AddMinutes(20) > DateTime.Now)
                {
                    PasswordResetVM model = new PasswordResetVM
                    {
                        Code = guid
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction("ExpiredPasswordCode");
                }
            }
        }

        [HttpPost]
        public ActionResult PasswordChange(PasswordResetVM model)
        {
            UserPasswordForget request = userPasswordForgetService.GetByCode(model.Code);

            if (string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Error = "Please fill up password field.";
                return View(model);
            }

            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View(model);
            }
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");

            if (!regex.IsMatch(model.ConfirmPassword))
            {
                ViewBag.Error = "Password must be at least 8 characters long and must contain letters and numbers.";
                return View(model);
            }

            request.CreatedOn = request.CreatedOn.AddMinutes(-30);
            userPasswordForgetService.Save();

            User user = userService.GetById(request.UserId);
            user.Password = model.ConfirmPassword;

            userService.Save();

            return RedirectToAction("Login");
        }
        public ActionResult ExpiredPasswordCode()
        {
            return View();
        }

        public ActionResult PasswordCustomChange()
        {
            PasswordChangeVM model = new PasswordChangeVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult PasswordCustomChange(PasswordChangeVM model)
        {
            User user = userService.GetById(SessionPersister.User.Id);

            if(user.Password != model.CurrentPassword)
            {
                ViewBag.Error = "Current password is invalid, please try again.";
                return View(model);
            }

            if (model.NewPassword != model.ConfirmPassword || String.IsNullOrEmpty(model.NewPassword))
            {
                ViewBag.Error = "Passwords do not match, please try again.";
                return View(model);
            }
            else
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
                if (!regex.IsMatch(model.ConfirmPassword))
                {
                    ViewBag.Error = "Password must be at least 8 characters long and must contain letters and numbers.";
                    return View(model);
                }
            }
            
            user.Password = model.ConfirmPassword;
            userService.Save();
            AccountModel am = new AccountModel(new List<User>());

            return RedirectToAction("Login");
        }
    }
}