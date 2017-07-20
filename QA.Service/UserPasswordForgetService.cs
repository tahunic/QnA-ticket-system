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
    public interface IUserPasswordForgetService
    {
        IEnumerable<UserPasswordForget> GetAll();
        UserPasswordForget GetById(int id);
        UserPasswordForget GetByCode(Guid guid);
        List<UserPasswordForget> GetByUser(int id);
        void Create(UserPasswordForget userPasswordForget);
        void Save();
    }
    public class UserPasswordForgetService : IUserPasswordForgetService
    {
        private readonly IUserPasswordForgetRepository passwordForgetRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserPasswordForgetService(IUserPasswordForgetRepository passwordForgetRepository, IUnitOfWork unitOfWork)
        {
            this.passwordForgetRepository = passwordForgetRepository;
            this.unitOfWork = unitOfWork;
        }

        #region Members

        public IEnumerable<UserPasswordForget> GetAll()
        {
            var passwordsForget = passwordForgetRepository.GetAll();
            return passwordsForget;
        }

        public UserPasswordForget GetById(int id)
        {
            var passwordForget = passwordForgetRepository.GetById(id);
            return passwordForget;
        }

        public UserPasswordForget GetByCode(Guid guid)
        {
            var passwordForget = passwordForgetRepository.Get(x=>x.Code == guid);
            return passwordForget;
        }

        public List<UserPasswordForget> GetByUser(int id)
        {
            var passwordForget = passwordForgetRepository.GetMany(x => x.UserId == id).ToList();
            return passwordForget;
        }

        public void Create(UserPasswordForget userPasswordForget)
        {
            passwordForgetRepository.Add(userPasswordForget);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
