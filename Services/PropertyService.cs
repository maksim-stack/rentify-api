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

        public List<Property> GetAll()
        {
            return _context.Properties.ToList();
        }

        public Property? GetById(int id)
        {
            return _context.Properties.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
        }

        public bool Update(Property property)
        {
            var updatePropety = _context.Properties.FirstOrDefault(p => p.Id == property.Id);

            if (updatePropety == null)
                return false;

            updatePropety.Title = property.Title;
            updatePropety.Description = property.Description;
            updatePropety.PricePerNight = property.PricePerNight;
            updatePropety.City = property.City;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        { 
            var deletePropety = _context.Properties.FirstOrDefault(p => p.Id == id);
            
            if (deletePropety == null)
                return false;

            _context.Properties.Remove(deletePropety);
            _context.SaveChanges();

            return true;
        }
    }
}
