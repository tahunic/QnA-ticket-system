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
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        void Create(User User);
        void Save();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository usersRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository usersRepository, IUnitOfWork unitOfWork)
        {
            this.usersRepository = usersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region Members

        public IEnumerable<User> GetAll()
        {
            var users = usersRepository.GetAll();
            return users;
        }

        public User GetById(int id)
        {
            var user = usersRepository.GetById(id);
            return user;
        }
        
        public User GetByEmail(string email)
        {
            var user = usersRepository.Get(x => x.Email.Equals(email));
            return user;
        }

        public void Create(User user)
        {
            usersRepository.Add(user);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
