using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitWithUs.Entities;

namespace VisitWithUs.DataAccess.Abstract
{
    public interface IPlaceRepository
    {
        Task<List<Place>> GetAllPlaces();

        Task<Place> GetPlaceById(int id);
        Task<Place> GetPlaceByName(string name);
        Task<Place> GetPlacesByNameOfCity(string name);
        Task<Place> CreatePlace(Place place);

        Task<Place> UpdatePlace(Place place);
        Task DeletePalceByName(string name);
        Task DeletePlaceById(int id);

    }
}
