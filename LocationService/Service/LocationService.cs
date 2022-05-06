using LocationService.Models;
using LocationService.Validations;
using LocationService.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace LocationService.Services
{
    public class LocationService : ILocationServices
    {
        private ILocationDataAccessLayer _locationDataAccessLayer;
        private Location _location = DataFactory.LocationDataFactory.GetLocationObject();
        private readonly ILogger _logger;
        public LocationService(ILogger logger)
        {
            _logger = logger;
            _locationDataAccessLayer = DataFactory.LocationDataFactory.GetLocationDataAccessLayerObject(_logger);
        }
        public bool CreateLocation(string locationName)
        {

            try
            {
                _location.LocationName = locationName;
                return _locationDataAccessLayer.AddLocationToDatabase(_location) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Location service : CreateLocation(string  locationName) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location service : CreateLocation(string locationName) : {exception.Message}");
                return false;
            }

        }

        public bool RemoveLocation(int locationId)
        {

            try
            {
                return _locationDataAccessLayer.RemoveLocationFromDatabase(locationId) ? true : false; 
            }
           catch (ArgumentException exception)
            {
                _logger.LogInformation($"Location service : RemoveLocation(int locationId) : {exception.Message}");
                return false;
            }
            catch (ValidationException locationNotFound)
            {
                _logger.LogInformation($"Location service : RemoveLocation(int locationId) : {locationNotFound.Message}");
                throw locationNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location service : RemoveLocation(int locationId) :{exception.Message}");
                return false;
            }
        }
        public IEnumerable<Location> ViewLocations()
        {
            try
            {
                IEnumerable<Location> locations = new List<Location>();
                return locations = from location in _locationDataAccessLayer.GetLocationsFromDatabase() where location.IsActive == true select location;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Location service:ViewLocations(): {exception.Message}");
                throw new Exception();
            }

        }

    }
}