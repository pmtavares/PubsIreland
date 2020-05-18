using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Cities
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCities();

        Task<IEnumerable<City>> GetCityByName(string name);
    }
}
