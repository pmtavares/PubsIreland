using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities;
        }

        public async Task<IEnumerable<City>> GetCityByName(string name)
        {
            var city = await _context.Cities.Where(c=> c.Name == name).ToArrayAsync();
            return city;
        }
    }
}
