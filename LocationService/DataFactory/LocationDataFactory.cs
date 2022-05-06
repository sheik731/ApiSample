using LocationService.DataAccessLayer;
using LocationService.Controllers;
using LocationService.Models;
using LocationService.Services;

public static class locationDataFactory
{
    public static ILocationDataAccessLayer GetLocationDataAccessLayerObject(ILogger _Logger)
    {
        return new locationDataAccessLayer(_Logger);
    }
    public static IlocationServices GetLocationServiceObject(ILogger _Logger)
    {
        return new LocationService(_logger);
    }
    public static Location GetLocationObject()
    {
        return new Location();
    }
}