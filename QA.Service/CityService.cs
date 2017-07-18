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
    public interface ICityService
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
        void Create(City city);
        void Save();
    }

    public class CityService : ICityService
    {
        private readonly ICityRepository citiesRepository;
        private readonly IUnitOfWork unitOfWork;

        public CityService(ICityRepository citiesRepository, IUnitOfWork unitOfWork)
        {
            this.citiesRepository = citiesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<City> GetAll()
        {
            var cities = citiesRepository.GetAll();
            return cities;
        }
        
        public City GetById(int id)
        {
            var city = citiesRepository.GetById(id);
            return city;
        }

        public void Create(City city)
        {
            citiesRepository.Add(city);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
