using QA.Data.Infrastructure;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public ProfessorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IProfessorRepository
    {
    }
}
