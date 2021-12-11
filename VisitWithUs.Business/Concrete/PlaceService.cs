using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitWithUs.Business.Abstract;
using VisitWithUs.DataAccess.Abstract;
using VisitWithUs.DataAccess.Concrete;
using VisitWithUs.Entities;

namespace VisitWithUs.Business.Concrete
{

    public class PlaceService : IPlaceService
    {
        private IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository) 
        {
            _placeRepository = placeRepository;
        }
        public async Task<Place> CreatePlace(Place place)
        {
            return await _placeRepository.CreatePlace(place);
        }

        public async Task DeletePalceByName(string name)
        {
            await _placeRepository.DeletePalceByName(name);
        }

        public async Task DeletePlaceById(int id)
        {
            await _placeRepository.DeletePlaceById(id);
        }

        public async Task<List<Place>> GetAllPlaces()
        {
            return await _placeRepository.GetAllPlaces();
        }

        public async Task<Place> GetPlaceById(int id)
        {
            return await _placeRepository.GetPlaceById(id);
        }

        public async Task<Place> GetPlaceByName(string name)
        {
            return await _placeRepository.GetPlaceByName(name);
        }

        public async Task<Place> GetPlacesByNameOfCity(string name)
        {
            return await _placeRepository.GetPlacesByNameOfCity(name);
        }

        public async Task<Place> UpdatePlace(Place place)
        {
           return await _placeRepository.UpdatePlace(place);
        }
    }
}
