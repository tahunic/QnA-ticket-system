using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Configuration
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Students");
            Property(s => s.IndexNumber).IsRequired().HasMaxLength(20);
        }
    }
}
