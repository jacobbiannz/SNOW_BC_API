using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data
{
    public class DbInitializer
    {
        public static void Initialize(BcApiDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Countries.Any())
            {
                return;
            }

            //-------------
            var Countries = new Country[]
            {
                new Country{Name="CHINA", CreatedDate = DateTime.Now },

            };

            foreach (Country c in Countries)
            {
                context.Countries.Add(c);
            }
            context.SaveChanges();

            //-------------
            var Proviences = new Provience[]
            {
                new Provience{Name="Beijing", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now },
                new Provience{Name="Shanghai", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now },
                new Provience{Name="Xizang", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now },
                new Provience{Name="Sichuan", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now },
                //new Provience{Name="Beijing", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now }
            };


            foreach (Provience p in Proviences)
            {
                context.Proviences.Add(p);
            }
            context.SaveChanges();

            //--------------
            var Cities = new City[]
            {
                new City{Name="Chengdu", Provience = Proviences.Last(), CreatedDate = DateTime.Now },
                new City{Name="Daocheng", Provience = Proviences.Last(), CreatedDate = DateTime.Now },
                new City{Name="Dujiangyan", Provience = Proviences.Last(), CreatedDate = DateTime.Now },
       
            };

            foreach (City c in Cities)
            {
                context.Cities.Add(c);
            }
            context.SaveChanges();
        }
    }
}
