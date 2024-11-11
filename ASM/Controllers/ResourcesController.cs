using System.ComponentModel.Design;
using ASM.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers;

[ApiController]
public class ResourcesController : ControllerBase
{
    private readonly IResourcesServices _resourceServices;

    public ResourcesController(IResourcesServices resourceServices) => _resourceServices = resourceServices;

    // Get all resources
    [HttpGet]
    [Route("/api/get-all-resources")]
    public async Task<IActionResult> GetAllResources()
    {
        try
        {
            var allResources = await _resourceServices.GetAllResources();
            return Ok(
                new
                {
                    status = true,
                    data = allResources
                }
            );
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


}
