using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Configuration
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("Questions");
            Property(q => q.Content).IsRequired().HasMaxLength(200);
            Property(q => q.Title).IsRequired().HasMaxLength(50);
            Property(q => q.StudentId).IsRequired();
            Property(q => q.SubjectId).IsRequired();
        }
    }
}
