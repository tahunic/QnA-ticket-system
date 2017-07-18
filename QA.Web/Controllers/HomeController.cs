using AutoMapper;
using QA.Model.Models;
using QA.Service;
using QA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService questionService;

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
                    Title = item.Title
                });
            }

            return View(questionsVM);
        }
    }
}