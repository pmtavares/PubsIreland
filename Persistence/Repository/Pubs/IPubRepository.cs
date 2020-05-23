using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Pubs
{
    public interface IPubRepository
    {
        Task<IEnumerable<Pub>> GetPubs();

        Task<Pub> GetPubById(int code);

        Task<IEnumerable<Pub>> GetPubsNumber(int total);

        Task<IEnumerable<Pub>> GetPubsByCity(string city);

        Task<IEnumerable<Pub>> GetOldestPubs(int number);

        Task<IEnumerable<Pub>> GetMostRecentAdded(int number);

        Task<bool> RegisterPubAsync(Pub pub);

        Task<bool> UpdatePub(Pub pub);

    }
}
