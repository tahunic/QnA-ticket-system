using QA.Data.Infrastructure;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory) {  }
        

    }

    public interface IQuestionRepository : IRepository<Question>
    {
    }
}
