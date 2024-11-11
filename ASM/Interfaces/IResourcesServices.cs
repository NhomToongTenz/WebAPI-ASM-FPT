using ASM.Models;

namespace ASM.Interface;

public interface IResourcesServices
{
    // Get all resources
    Task<List<Resources>> GetAllResources();
}
