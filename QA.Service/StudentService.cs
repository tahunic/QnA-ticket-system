using QA.Data.Infrastructure;
using QA.Data.Repositories;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Service
{
    // operations you want to expose
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Create(Student student);
        void Save();
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
        }

        #region Members

        public IEnumerable<Student> GetAll()
        {
            var students = studentRepository.GetAll();
            return students;
        }

        public Student GetById(int id)
        {
            var student = studentRepository.GetById(id);
            return student;
        }

        public void Create(Student student)
        {
            studentRepository.Add(student);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
