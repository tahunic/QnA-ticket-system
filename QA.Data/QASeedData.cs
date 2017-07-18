using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data
{
    public class QASeedData : DropCreateDatabaseIfModelChanges<QAEntities>
    {
        protected override void Seed(QAEntities context)
        {
            GetCities().ForEach(c => context.Cities.Add(c));
            GetProfessors().ForEach(p => context.Professors.Add(p));
            GetStudents().ForEach(s => context.Students.Add(s));
            GetSubjects().ForEach(s => context.Subjects.Add(s));
            //GetQuestions().ForEach(q => context.Questions.Add(q));

            base.Seed(context);
        }

        #region Function implementation
        private static List<City> GetCities()
        {
            return new List<City>
            {
                new City
                {
                    IsDeleted = false,
                    Name = "Vitez"
                },
                new City
                {
                    IsDeleted = false,
                    Name = "Sarajevo"
                },
                new City
                {
                    IsDeleted = false,
                    Name = "Mostar"
                }
            };
        }

        private static List<Professor> GetProfessors()
        {
            return new List<Professor>
            {
                new Professor
                {
                    IsDeleted = false,
                    Title = "mr.",
                    User = new User
                    {
                        IsDeleted = false,
                        Fname = "Denis",
                        Lname = "Music",
                        Email = "denis@fit.ba",
                        Username = "denis",
                        Password = "test",
                        CityId = 1
                    }
                }
            };
        }

        private static List<Student> GetStudents ()
        {
            return new List<Student>
            {
                new Student
                {
                    IsDeleted = false,
                    IndexNumber = "IB140072",
                    User = new User
                    {
                        IsDeleted = false,
                        Fname = "Nihad",
                        Lname = "Tahunic",
                        Email = "nihad@fit.ba",
                        Username = "nihad",
                        Password = "test",
                        CityId = 2
                    }
                }
            };
        }

        private static List<Subject> GetSubjects()
        {
            return new List<Subject>
            {
                new Subject
                {
                    IsDeleted = false,
                    Semester = 1,
                    Year = 1,
                    Title = "Programiranje I"
                },
                new Subject
                {
                    IsDeleted = false,
                    Semester = 2,
                    Year = 1,
                    Title = "Programiranje II"
                },
                new Subject
                {
                    IsDeleted = false,
                    Semester = 5,
                    Year = 3,
                    Title = "Razvoj softvera"
                },
            };
        }

        private static List<Question> GetQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    IsDeleted = false,
                    Date = DateTime.Now,
                    Title = "Neko pitanje",
                    Content = "Pitanje neko  sadrzaj",
                    IsPublic = false,
                    StudentId = 1,
                    SubjectId = 1,
                    ViewCount = 0
                },
                new Question
                {
                    IsDeleted = false,
                    Date = DateTime.Now,
                    Title = "Neko pitanje 2",
                    Content = "Pitanje neko  sadrzaj 2",
                    IsPublic = false,
                    StudentId = 1,
                    SubjectId = 2,
                    ViewCount = 0
                },
                new Question
                {
                    IsDeleted = false,
                    Date = DateTime.Now,
                    Title = "Neko pitanje 2",
                    Content = "Pitanje neko  sadrzaj 2",
                    IsPublic = false,
                    StudentId = 1,
                    SubjectId = 2,
                    ViewCount = 0
                }
            };
        }
        #endregion
    }
}
