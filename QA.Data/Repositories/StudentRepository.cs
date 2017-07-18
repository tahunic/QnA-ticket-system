using QA.Data.Infrastructure;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IStudentRepository : IRepository<Student>
    {
    }
}
