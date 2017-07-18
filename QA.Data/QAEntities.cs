using QA.Data.Configuration;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data
{
    public class QAEntities: DbContext
    {
        public QAEntities():base("QAEntities")
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new ProfessorConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<User>().HasOptional(x => x.Student).WithRequired(y => y.User);
            modelBuilder.Entity<User>().HasOptional(x => x.Professor).WithRequired(z => z.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
