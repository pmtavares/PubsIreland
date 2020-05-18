using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructured.Errors;
using Persistence.Repository.Cities;

namespace Application.Services
{
    public class CityServicesImpl : ICityServices
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;
        public CityServicesImpl(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CityDto>> GetCities()
        {
            var cities = await _repository.GetCities();

            if(cities == null)
            {
                throw new RestExceptions(HttpStatusCode.NotFound, new { Cities = "Not found" });
            }

            var result = _mapper.Map<IEnumerable<CityDto>>(cities);
            return result;

        }
    }
}
