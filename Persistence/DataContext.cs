using Domain;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pub> Pubs { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}
