using RentalApp.Data;
using RentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RentalApp.Services
{
    public class PropertyService
    {
        private readonly AppDbContext _context;

        public PropertyService(AppDbContext context) {
            _context = context;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Property property)
        {
            var updatePropety = await _context.Properties.FirstOrDefaultAsync(p => p.Id == property.Id);

            if (updatePropety == null)
                return false;

            updatePropety.Title = property.Title;
            updatePropety.Description = property.Description;
            updatePropety.PricePerNight = property.PricePerNight;
            updatePropety.City = property.City;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        { 
            var deletePropety = await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);
            
            if (deletePropety == null)
                return false;

            _context.Properties.Remove(deletePropety);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
