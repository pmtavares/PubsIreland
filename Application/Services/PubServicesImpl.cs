using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructured.Errors;
using Microsoft.Extensions.Logging;
using Persistence.Repository.Cities;
using Persistence.Repository.Pubs;

namespace Application.Services
{
    public class PubServicesImpl : IPubServices
    {
        private readonly IPubRepository _repository;
        private readonly ICityRepository _cityRepository;

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public PubServicesImpl(IPubRepository repository, ILogger<Pub> logger, IMapper mapper, ICityRepository city)
        {
            _repository = repository;
            _cityRepository = city;
            _logger = logger;
            _mapper = mapper;


        }
        public async Task<IEnumerable<PubDto>> GetAllPubs()
        {
            try
            {
                var pubs = await _repository.GetPubs();
                var pubsToReturn = _mapper.Map<IEnumerable<PubDto>>(pubs);

                return pubsToReturn;
            }
            catch(Exception err)
            {
                _logger.LogError($"Error: {err.Message}");
                throw;
            }

        }

        public async Task<PubDto> GetPubById(int code)
        {
      
            var pub = await _repository.GetPubById(code);


            if (pub == null)
            {
                throw new RestExceptions(HttpStatusCode.NotFound, new
                {
                    pub = "Not Found"
                });
            }

            var pubToReturn = _mapper.Map<Pub, PubDto>(pub);

            return pubToReturn;

        }

        

        public async Task<IEnumerable<PubDto>> GetPubsNumber(int total)
        {
            try
            {
                var pubs = await _repository.GetPubsNumber(total);
                var pubsToReturn = _mapper.Map<IEnumerable<PubDto>>(pubs);

                return pubsToReturn;
            }
            catch (Exception err)
            {
                _logger.LogError($"Error: {err.Message}");
                throw;
            }

        }

        public async Task<IEnumerable<PubDto>> GetPubsByCity(string city)
        {
            try
            {
                var pubs = await _repository.GetPubsByCity(city);
                var pubsToReturn = _mapper.Map<IEnumerable<PubDto>>(pubs);

                return pubsToReturn;
            }
            catch (Exception err)
            {
                _logger.LogError($"Error: {err.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PubDto>> GetOldestPubs(int number)
        {
            var pubs = await _repository.GetOldestPubs(number);
            if (pubs == null)
            {
                throw new RestExceptions(HttpStatusCode.NotFound, new
                {
                    pubs = "Pubs could not be found"
                });
            }

            var pubsToReturn = _mapper.Map<IEnumerable<PubDto>>(pubs);

            return pubsToReturn;

        }

        public async Task<IEnumerable<PubDto>> GetRecentAdded(int number)
        {
            var pubs = await _repository.GetMostRecentAdded(number);

            if(pubs == null)
            {
                throw new RestExceptions(HttpStatusCode.NotFound, new
                {
                    pubs = "Pubs could not be found"
                });
            }
            var pubsToReturn = _mapper.Map<IEnumerable<PubDto>>(pubs);
            return pubsToReturn;
        }

        public async Task<bool> RegisterPubAsync(PubDtoForCreation dto)
        {
            if(dto == null)
            {
                throw new RestExceptions(HttpStatusCode.BadRequest, new { Pub = "Pub invalid" });
            }


            dto.DateAdded = DateTime.Now;
            dto.ImagePath = "assets/images/pubs/noimage.jpg";

            var pubToSave = _mapper.Map<PubDtoForCreation, Pub>(dto);

        
            return await _repository.RegisterPubAsync(pubToSave);
        }
    }
}
