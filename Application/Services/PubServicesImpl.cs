using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructured.Errors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Persistence.Repository.Auth;
using Persistence.Repository.Cities;
using Persistence.Repository.Pubs;

namespace Application.Services
{
    public class PubServicesImpl : IPubServices
    {
        private readonly IPubRepository _repository;
        private readonly IAuthRepository _authRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IConfiguration _config;

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public PubServicesImpl(IPubRepository repository, ILogger<Pub> logger, 
                    IMapper mapper, ICityRepository city, IAuthRepository authRep, IConfiguration  config)
        {
            _repository = repository;
            _cityRepository = city;
            _logger = logger;
            _mapper = mapper;
            _authRepository = authRep;
            _config = config;


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

        public async Task<PubDto> RegisterPubAsync(PubDtoForCreation dto)
        {
            if(dto == null)
            {
                throw new RestExceptions(HttpStatusCode.BadRequest, new { Pub = "Pub cannot be null" });
            }


            dto.DateAdded = DateTime.Now;
            dto.ImagePath = "assets/images/pubs/noimage.jpg";


            if(await _authRepository.UserExists(dto.Username.ToLower()))
            {
                throw new RestExceptions(HttpStatusCode.BadRequest, new { Pub = "Invalid Pub" });
            }

            var pubToSave = _mapper.Map<PubDtoForCreation, Pub>(dto);

            var toReturn = await _authRepository.RegisterPubAsync(pubToSave, dto.Password );
            var result = _mapper.Map<Pub, PubDto>(toReturn);
            return result;
            
        }

        public async Task<string> Login(string username, string password)
        {
            var pub = await _authRepository.Login(username, password);

            if(pub == null)
            {
                throw new RestExceptions(HttpStatusCode.Unauthorized, new { Pub = "Unauthorized" });
            }


            //Build token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, pub.Id.ToString()),
                new Claim(ClaimTypes.Name, pub.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
