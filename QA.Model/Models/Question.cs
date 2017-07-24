using QA.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Model.Models
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
        public int ViewCount { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }


        public virtual Student Student { get; set; }
        public int StudentId { get; set; }

        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }        
    }
}
