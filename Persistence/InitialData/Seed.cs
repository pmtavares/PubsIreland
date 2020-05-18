using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.InitialData
{
    public class Seed
    {

        public static void SeedData(DataContext context)
        {
            if(!context.Cities.Any())
            {
                var cities = new List<City>
                {
                    new City
                    {
                        Name="Dublin",
                        County= "Dublin"
                    },
                    new City
                    {
                        Name="Galway City",
                        County="Galway"
                    },
                    new City
                    {
                        Name="Cork City",
                        County="Cork"
                    },
                    new City
                    {
                        Name="Limerick City",
                        County="Limerick"
                    },
                    new City
                    {
                        Name="Ashbourne",
                        County="Meath"
                    }
                };
                context.Cities.AddRange(cities);
            }
            context.SaveChanges();
            
        }
    }
}
