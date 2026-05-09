using RentalApp.Models;

namespace RentalApp.Services
{
    public class PropertyService
    {
        private readonly List<Property> _properties = new();

        public PropertyService() {
            _properties.Add(new Property
            {
                Id = 1,
                Title = "Title",
                Description = "Description",
                PricePerNight = 100,
                City = "Kyiv"
            });
        }

        public List<Property> GetAll()
        {
            return _properties;
        }

        public Property? GetById(int id)
        {
            return _properties.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Property property)
        {
            property.Id = _properties.Max(p => p.Id) + 1;
            _properties.Add(property);
        }

        public bool Update(Property property)
        {
            var updatePropety = _properties.FirstOrDefault(p => p.Id == property.Id);

            if (updatePropety == null)
                return false;

            updatePropety.Title = property.Title;
            updatePropety.Description = property.Description;
            updatePropety.PricePerNight = property.PricePerNight;
            updatePropety.City = property.City;
            updatePropety.OwnerId = property.OwnerId;

            return true;
        }

        public bool Delete(int id)
        { 
            var deletePropety = _properties.FirstOrDefault(p => p.Id == id);
            
            if (deletePropety == null)
                return false;

            _properties.Remove(deletePropety);

            return true;
        }
    }
}
