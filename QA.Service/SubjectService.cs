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
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        void Create(Subject subject);
        void Save();
    }
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectsRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubjectService(ISubjectRepository subjectsRepository, IUnitOfWork unitOfWork)
        {
            this.subjectsRepository = subjectsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region Members

        public IEnumerable<Subject> GetAll()
        {
            var subjects = subjectsRepository.GetAll();
            return subjects;
        }

        public Subject GetById(int id)
        {
            var subject = subjectsRepository.GetById(id);
            return subject;
        }

        public void Create(Subject subject)
        {
            subjectsRepository.Add(subject);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
