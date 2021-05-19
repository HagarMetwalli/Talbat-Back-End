using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Services
{
    public class City1Service : IGenericService<City>
    {
        private readonly TalabatContext db;

        public City1Service(TalabatContext db) 
        {
            this.db = db;
        }

        public async Task<City> CreatAsync(City c)
        {
            EntityEntry<City> added = await db.Cities.AddAsync(c);

            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                return c;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            City c = db.Cities.Find(id);

            db.Cities.Remove(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Task<IEnumerable<City>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<City>>(() => db.Cities.ToList());
        public Task<IEnumerable<City>> RetriveAllAsync() => Task<IEnumerable>.Run<IEnumerable<City>>(() => db.Cities.ToList());

        //public List<City> RetriveCitiesAsync()
        //{
        //    return db.Cities.ToList();
        //}

        public async Task<City> RetriveAsync(int id)
        {
            City cFound = db.Cities.Find(id);

            if (cFound != null)
            {
                return cFound;
            }
            return null;
        }

        public async Task<City> UpdateAsync(int id, City c)
        {
            TalabatContext d = new TalabatContext();

            //using (var d= new TalabatContext())
            //{

                //City old = d.Cities.Find(id);

                //if (old != null)
                //{
                    //db.Cities.Update(c);
                    d.Entry(c).State = EntityState.Modified;

                    int affected = await d.SaveChangesAsync();

                    if (affected == 1)
                    {
                        return c;
                    }
                //}
                return null;
            //}
        }

    }
}


//old.CityName = c.CityName;
//old.ClientAddresses = c.ClientAddresses;


