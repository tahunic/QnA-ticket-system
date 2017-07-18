using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.ViewModels
{
    public class QuestionsDisplayVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public bool IsPublic { get; set; }
    }
}