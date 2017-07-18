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
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        void Create(Question question);
        void Save();
    }
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public QuestionService(IQuestionRepository questionsRepository, IUnitOfWork unitOfWork)
        {
            this.questionsRepository = questionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region Members

        public IEnumerable<Question> GetAll()
        {
            var questions = questionsRepository.GetAll();
            return questions;
        }

        public Question GetById(int id)
        {
            var question = questionsRepository.GetById(id);
            return question;
        }

        public void Create(Question question)
        {
            questionsRepository.Add(question);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
