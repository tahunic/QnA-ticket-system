using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Configuration
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            ToTable("Subjects");
            Property(s => s.Title).IsRequired().HasMaxLength(30);
        }
    }
}
