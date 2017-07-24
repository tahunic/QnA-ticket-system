using AutoMapper;
using QA.Model.Models;
using QA.Service;
using QA.Web.Helper;
using QA.Web.Security;
using QA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService questionService;
        private WebAPIHelper usersAPIService = new WebAPIHelper("api/users", SessionPersister.Jwt);

        public HomeController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            List<Question> questions = questionService.GetAll().ToList();
            List<QuestionsDisplayVM> questionsVM = new List<QuestionsDisplayVM>();

            foreach (var item in questions)
            {
                questionsVM.Add(new QuestionsDisplayVM
                {
                    Id = item.Id,
                    Content = item.Content,
                    IsPublic = item.IsPublic,
                    Subject = item.Subject.Title,
                    Title = item.Title,
                    ImagePath = item.ImagePath
                });
            }

            return View(questionsVM);
        }

        public ActionResult WebAPItest()
        {
            User user = null;
            HttpResponseMessage response = usersAPIService.GetResponse("1");
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<User>().Result;
            }

            return View(user);
        }

        public ActionResult Pictures()
        {
            List<Question> questions = questionService.GetAll().ToList();

            List<QuestionsDisplayVM> questionsVM = new List<QuestionsDisplayVM>();
            foreach (var item in questions)
            {
                questionsVM.Add(new QuestionsDisplayVM
                {
                    Id = item.Id,
                    Content = item.Content,
                    IsPublic = item.IsPublic,
                    Subject = item.Subject.Title,
                    Title = item.Title,
                    ImagePath = item.ImagePath
                });
            }

            return View(questionsVM);
        }
    }
}