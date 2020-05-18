using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICityServices
    {
        Task<IEnumerable<CityDto>> GetCities();

        Task<IEnumerable<CityDto>> GetCities(string name);
    }
}
