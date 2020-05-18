using Application.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPubServices
    {
        Task<IEnumerable<PubDto>> GetAllPubs();

        Task<PubDto> GetPubById(int code);

        Task<IEnumerable<PubDto>> GetPubsNumber(int total);

        Task<IEnumerable<PubDto>> GetPubsByCity(string city);

        Task<IEnumerable<PubDto>> GetOldestPubs(int number);

        Task<IEnumerable<PubDto>> GetRecentAdded(int number);

        Task<bool> RegisterPubAsync(PubDtoForCreation dto);
    }
}
