using System;
using System.Collections.Generic;
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

        public async Task<City> GetCityByName(string name)
        {
            var city = await _context.Cities.SingleOrDefaultAsync(c => c.Name == name);
            return city;
        }
    }
}
