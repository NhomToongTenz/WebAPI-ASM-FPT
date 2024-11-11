using ASM.Appdatacontext;
using ASM.Interface;
using ASM.Models;

namespace ASM.Services;

public class ResourcesServices : IResourcesServices
{
    private AppDataContext _context;

    public ResourcesServices(AppDataContext context) => _context = context;

    public Task<List<Resources>> GetAllResources()
    {
        try {
            var rs = _context.Resources.ToList();
            return Task.FromResult(rs);
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}
