using QA.Web.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.ViewModels
{
    public class QuestionEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public List<SelectListItem> Subject { get; set; }
        public int SubjectId { get; set; }
        public bool IsPublic { get; set; }

        [ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1 MB")]
        public HttpPostedFileBase File { get; set; }
    }
}