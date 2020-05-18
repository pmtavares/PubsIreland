using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository.Pubs
{
    public class PubRepository : IPubRepository
    {
        private readonly DataContext _context;

        public PubRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Pub> GetPubById(int code)
        {
            var pub = await _context.Pubs.Include(x=> x.City).SingleOrDefaultAsync(x => x.Id == code);
            return pub;
        }

        public async Task<IEnumerable<Pub>> GetPubs()
        {
            var pubs = await _context.Pubs.Include(x=> x.City).ToListAsync();
            return pubs;
        }

        

        public async Task<IEnumerable<Pub>> GetPubsNumber(int total)
        {
            var pubs = await _context.Pubs.Include(x => x.City).Take(total).ToListAsync();
            return pubs;
        }

        public async Task<IEnumerable<Pub>> GetPubsByCity(string city)
        {
            var pubs = await  _context.Pubs.Include(x => x.City).Where(x => x.City.Name == city).ToListAsync();
            return pubs;

        }

        public async Task<IEnumerable<Pub>> GetOldestPubs(int number)
        {
            var pubs = await _context.Pubs.Include(x => x.City)
                                            .Take(number)
                                            .OrderBy(x => x.DateFounded).ToListAsync();
            return pubs;
        }

        public async Task<IEnumerable<Pub>> GetMostRecentAdded(int number)
        {
            var pubs = await _context.Pubs.Include(x => x.City).OrderByDescending(x => x.DateAdded).Take(number)
                .ToListAsync();
            return pubs;
        }

        public async Task<bool> RegisterPubAsync(Pub pub)
        {
            _context.Pubs.Add(pub);
            return  await _context.SaveChangesAsync() > 0;
        }

      
    }
}
