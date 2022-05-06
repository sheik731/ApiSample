using LocationService.Models;

namespace LocationService.Services{
    public interface ILocationServices
    {
        public  bool CreateLocation(string locationName);
        public bool RemoveLocation(int locationId);
        public IEnumerable<Location> ViewLocations();

    }
}