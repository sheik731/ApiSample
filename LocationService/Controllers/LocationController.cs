using Microsoft.AspNetCore.Mvc;
using locationservice.Models;
using locationservice.Validations;
using System.ComponentModel.DataAnnotations;
using locationservice.Services;
using System.Net;

namespace locationservice.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class LocationController : ControllerBase
{
private readonly ILogger _Logger;
private ILocationService _LocationService; 
public LocationController(ILogger<LocationController> logger)
{
    _Logger = logger;
    _LocationService = DataFactory.locationDataFactory.GetLocationServiceObject(_Logger)
}
 [HttpPost]
    public IActionResult CreateNewLocation(string locationName)
    {
        if(locationName == null)
            return BadRequest("Location Field Can't Be Empty");
        try
        {
            return _locationService.CreateLocation(locationName) ? Ok("Location Added") : Problem("Sorry internal error occured");
        }
        catch (ValidationException locationNameException)
        {
            _logger.LogInformation($"Location Service : CreateNewLocation() : {locationNameException.Message}");
            return BadRequest(locationNameException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : CreateLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemoveLocation(int locationId)
    {
        if(locationId == 0)
            return BadRequest("Location Id can't be null");
        try
        {
            return _locationService.RemoveLocation(locationId) ? Ok("Location Removed") : Problem("Sorry internal error occured");
        }
         catch (ValidationException locationNotFound)
        {
            _logger.LogInformation($"Location Service : RemoveLocation() : {locationNotFound.Message}");
            return BadRequest(locationNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : RemoveLocation throwed an exception : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
      
    }
    [HttpGet]
    public IActionResult ViewLocations()
    {
        try
        {
            return Ok(_locationService.ViewLocations());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching locations ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}