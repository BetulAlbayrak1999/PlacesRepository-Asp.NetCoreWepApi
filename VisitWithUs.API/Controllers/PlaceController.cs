using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWithUs.Business.Abstract;
using VisitWithUs.Business.Concrete;
using VisitWithUs.Entities;

namespace VisitWithUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : Controller
    {
        private IPlaceService _placeService;
        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var AllPlace = await _placeService.GetAllPlaces();
            return Ok(AllPlace); //200+ data
        }

        [HttpGet]
        [Route ("[action]/{id}")] //yazılan action şeklinde request at, action'nın kendi adını olmayabilir
        public async Task<IActionResult> GetPalceById(int id)
        {
            var place = await _placeService.GetPlaceById(id);
            if(place != null)
            {
                return Ok(place);
            }
            
                return NotFound();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetPlaceByName(string name) 
        {
            var place = await _placeService.GetPlaceByName(name);
            if (place != null) 
            {
                return Ok(place);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetPlacesByNameOfCity(string name)
        {
            var place = await _placeService.GetPlacesByNameOfCity(name);
            if (place != null)
            {
                return Ok(place);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody]Place place)
        {
            if (ModelState.IsValid) 
            {
                var createdPlace = await _placeService.CreatePlace(place);
                return CreatedAtAction("Get", new { id = createdPlace.PlaceId}, createdPlace);
            }
            return BadRequest(ModelState); //400 + validation errors
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put([FromBody]Place place)
        {
            if (await _placeService.GetPlaceById(place.PlaceId) != null) 
            {
                return Ok(await _placeService.UpdatePlace(place));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteById(int id) 
        {
            if (await _placeService.GetPlaceById(id) != null) 
            {
                await _placeService.DeletePlaceById(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            if (await _placeService.GetPlaceByName(name) != null)
            {
                await _placeService.DeletePalceByName(name);
                return Ok();
            }
            return NotFound();
        }
    }
}
