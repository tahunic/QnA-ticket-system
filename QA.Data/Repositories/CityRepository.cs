using QA.Data.Infrastructure;
using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory) : base(dbFactory) { }


    }

    public interface ICityRepository : IRepository<City>
    {

    }
}
