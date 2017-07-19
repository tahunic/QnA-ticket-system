using QA.Model.Models;
using QA.Service;
using QA.Web.Security;
using QA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly IQuestionService questionService;

        public QuestionController(ISubjectService subjectService, IQuestionService questionService)
        {
            this.subjectService = subjectService;
            this.questionService = questionService;
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            List<Subject> subjects = subjectService.GetAll().ToList();
            QuestionEditVM questionVM = new QuestionEditVM();

            questionVM.Subject = subjects.Select(s => new SelectListItem
            {
                Text = s.Title,
                Value = s.Id.ToString()
            }).ToList();

            if(id.HasValue)
            {
                Question question = questionService.GetById((int)id);

                questionVM.Id = question.Id;
                questionVM.Title = question.Title;
                questionVM.Content = question.Content;
                questionVM.SubjectId = question.SubjectId;
                questionVM.IsPublic = question.IsPublic;
            }
            return View(questionVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index","Home");
            }
            Question question;

            if(model.Id == 0)
            {
                question = new Question
                {
                    Title = model.Title,
                    Content = model.Content,
                    IsDeleted = false,
                    IsPublic = model.IsPublic,
                    StudentId = 3,
                    SubjectId = model.SubjectId,
                    Date = DateTime.Now,
                    ViewCount = 0
                };

                questionService.Create(question);
                questionService.Save();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                question = questionService.GetById(model.Id);

                question.IsPublic = model.IsPublic;
                question.StudentId = 3;
                question.SubjectId = model.SubjectId;
                question.Title = model.Title;
                question.Content = model.Content;
                question.Date = DateTime.Now;

                questionService.Save();

                return RedirectToAction("Index", "Home");
            }            
        }

        public ActionResult Delete(int id)
        {
            Question question = questionService.GetById(id);
            question.IsDeleted = true;

            questionService.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}