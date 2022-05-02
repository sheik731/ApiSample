using Microsoft.AspNetCore.Mvc;
using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
using System.Net;

namespace InterviewManagementSystemAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PoolController : ControllerBase
{
    private readonly ILogger _logger;
    public PoolController(ILogger<PoolController> logger)
    {
        _logger = logger;
    }
    IPoolService PoolService = DataFactory.PoolDataFactory.GetPoolServiceObject();

    [HttpPost]
    public IActionResult CreateNewPool(string PoolName, int DeptId)
    {
        if (PoolName == null || DeptId == null) 
            return BadRequest("Pool name is required");

        try
        {
            return PoolService.CreatePool(PoolName) ? Ok("Pool Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : CreatePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemovePool(int PoolId, string DeptId)
    {
        if (PoolId == 0 || DeptId == 0) return BadRequest("Pool Id is not provided");

        try
        {
            return PoolService.RemovePool(PoolId) ? Ok("Pool Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : RemovePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewPools()
    {
        try
        {
            return Ok(PoolService.ViewPools(DeptId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching Pools ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    
    [HttpPost]
    public IActionResult AddPoolMembers(int EmployeeID, int PoolId)
    {
        if (EmployeeID == null || PoolId == null) 
            return BadRequest("Pool Id is required");

        try
        {
            return PoolService.AddPoolMembers(EmployeeID) ? Ok("Employee Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : Add Employee throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    
    [HttpPost]
    public IActionResult RemovePoolMembers(int EmployeeID, int PoolId)
    {
        if (EmployeeID == null || PoolId == null) 
            return BadRequest("Pool Id is required");

        try
        {
            return PoolService.RemovePoolMembers(EmployeeID) ? Ok("Employee Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : RemovePoolMembers throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpGet]
    public IActionResult ViewPoolMembers(int DeptId, int PoolId, int RoleId, String EmployeeName)
    {
        try
        {
            return Ok(PoolService.ViewPoolMemberss());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching Pool Members ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}
