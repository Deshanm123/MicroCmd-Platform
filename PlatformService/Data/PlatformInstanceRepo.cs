using System.Linq;
using PlatformService.Data.Interface;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformInstanceRepo : IPlatformInstanceRepoInterface
    {
        private readonly ApplicationDbContext _context;
        public PlatformInstanceRepo(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void CreatePlatform(PlatformInstance platformInstance)
        {
            ArgumentNullException.ThrowIfNull(platformInstance);
            _context.PlatformInstances.Add(platformInstance);
        }

        public IEnumerable<PlatformInstance> GetAllPlatformInstances()
        {
            if(_context.PlatformInstances != null)
                return _context.PlatformInstances.ToList();
            else
               return new List<PlatformInstance>();

        }

        public PlatformInstance GetPlatformById(int Id)
        {
            if(Id == 0){
                Console.WriteLine($"{Id}  is not a valid Id");
                return null;
            }
            return _context.PlatformInstances.FirstOrDefault(plt => plt.Id ==Id);
        }

        public bool SaveChanges()
        {
            try{
                bool isDataSaved = _context.SaveChanges() > 0 ;
                return isDataSaved;
            }catch(Exception ex){
                throw new Exception($"Error Saving Changes :{ex.ToString()}");
            }
        }
    }
}