using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitWithUs.DataAccess.Abstract;
using VisitWithUs.Entities;

namespace VisitWithUs.DataAccess.Concrete
{
    public class PlaceRepository : IPlaceRepository
    {
        public async Task<Place> CreatePlace(Place place)
        {
            Context myDbContext = new Context();
            myDbContext.places.Add(place);
            await myDbContext.SaveChangesAsync();
            return place;
        }
        public async Task<Place> GetPlaceByName(string name)
        {
            Context myDbContext = new Context();
            return await myDbContext.places.FirstOrDefaultAsync(x => x.PlaceName.ToLower() == name.ToLower());
        }

        public async Task DeletePalceByName(string name)
        {

            Context myDbContext = new Context();
            Place deletedPlace = await GetPlaceByName(name);
            myDbContext.places.Remove(deletedPlace);
            await myDbContext.SaveChangesAsync();
        }

        public async Task DeletePlaceById(int id)
        {
            Context myDbContext = new Context();
            Place deletedPlace = await GetPlaceById(id);
            myDbContext.places.Remove(deletedPlace);
            await myDbContext.SaveChangesAsync();
        }

        public async Task<List<Place>> GetAllPlaces()
        {
            Context myDbContext = new Context();
            return await myDbContext.places.ToListAsync();
        }

        public async Task<Place> GetPlaceById(int id)
        {
            Context myDbContext = new Context();
            return await myDbContext.places.FindAsync(id);
        }
        
        public async Task<Place> UpdatePlace(Place place)
        {
            Context myDbContext = new Context();
            myDbContext.places.Update(place);
            await myDbContext.SaveChangesAsync();
            return place;
        }

        public async Task<Place> GetPlacesByNameOfCity(string name)
        {
            Context myDbContext = new Context();
            return await myDbContext.places.FirstOrDefaultAsync(x => x.CityName.ToLower() == name.ToLower());

        }
    }
}
