using Microsoft.AspNetCore.Mvc;
using RentalApp.DTOs;
using RentalApp.Models;
using RentalApp.Services;

namespace RentalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_propertyService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var property = _propertyService.GetById(id);

            if (property == null)
                return NotFound();

            return Ok(property);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePropertyDto dto)
        {
            var property = new Property
            {
                Title = dto.Title!,
                Description = dto.Description,
                PricePerNight = dto.PricePerNight,
                City = dto.City!
            };

            _propertyService.Add(property);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id = property.Id },
                property);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePropertyDto dto)
        {
            var property = new Property
            {
                Id = id,
                Title = dto.Title!,
                Description = dto.Description,
                PricePerNight = dto.PricePerNight,
                City = dto.City!
            };

            var updated = _propertyService.Update(property);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _propertyService.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
