using QA.Data.Infrastructure;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Repositories
{
    public class UserPasswordForgetRepository : RepositoryBase<UserPasswordForget>, IUserPasswordForgetRepository
    {
        public UserPasswordForgetRepository(IDbFactory dbFactory) : base(dbFactory) { }
         
    }

    public interface IUserPasswordForgetRepository : IRepository<UserPasswordForget>
    {
    }
}
