using Microsoft.CodeAnalysis;
using PlatformService.Models;

namespace PlatformService.Data.Interface
{
    public interface IPlatformInstanceRepo
    {

        IEnumerable<PlatformInstance> GetAllPlatformInstances();
        PlatformInstance GetPlatformById(int Id);
        
        void CreatePlatform(PlatformInstance platformInstance);

        bool SaveChanges();
    }
    
}  