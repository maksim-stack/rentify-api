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
        public async Task<IActionResult> GetAll() 
        {
            var properties = await _propertyService.GetAllAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var property = await _propertyService.GetByIdAsync(id);

            if (property == null)
                return NotFound();

            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyDto dto)
        {
            var property = new Property
            {
                Title = dto.Title!,
                Description = dto.Description,
                PricePerNight = dto.PricePerNight,
                City = dto.City!
            };

            await _propertyService.AddAsync(property);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id = property.Id },
                property);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePropertyDto dto)
        {
            var property = new Property
            {
                Id = id,
                Title = dto.Title!,
                Description = dto.Description,
                PricePerNight = dto.PricePerNight,
                City = dto.City!
            };

            var updated = await _propertyService.UpdateAsync(property);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _propertyService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
