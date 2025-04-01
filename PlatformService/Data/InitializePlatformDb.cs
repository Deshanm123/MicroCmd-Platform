
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class InitializePlatformDb
    {
        public static void InitPopulation(IApplicationBuilder application){
            using (var serviceScope = application.ApplicationServices.CreateScope())
            {
                try
                {
                    ApplicationDbContext? context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                    if(context  != null){
                        SeedData(context);
                    }else{
                        throw new ArgumentNullException(nameof(ApplicationDbContext));
                    }
                }
                catch(Exception ex){    
                    Console.WriteLine($"Platform DbContext Error : {ex.ToString()}");
                }
            }
        }

        private static void SeedData(ApplicationDbContext context){

            if(context != null && !context.PlatformInstances.Any()){

                    List<PlatformInstance> platformList = new List<PlatformInstance>()
                    {
                        new PlatformInstance { Id = 2, Name = "Xbox Series X", Publisher = "Microsoft", Cost = 499.99 },
                        new PlatformInstance { Id = 3, Name = "Nintendo Switch", Publisher = "Nintendo", Cost = 299.99 },
                        new PlatformInstance { Id = 4, Name = "Steam Deck", Publisher = "Valve", Cost = 399.99 },
                        new PlatformInstance { Id = 1, Name = "PlayStation 5", Publisher = "Sony", Cost = 499.99 },
                        new PlatformInstance { Id = 5, Name = "PlayStation 4", Publisher = "Sony", Cost = 299.99 },
                        new PlatformInstance { Id = 6, Name = "Xbox One", Publisher = "Microsoft", Cost = 249.99 },
                        new PlatformInstance { Id = 7, Name = "Nintendo Wii", Publisher = "Nintendo", Cost = 199.99 },
                        new PlatformInstance { Id = 8, Name = "Sega Genesis", Publisher = "Sega", Cost = 89.99 },
                        new PlatformInstance { Id = 9, Name = "Atari 2600", Publisher = "Atari", Cost = 49.99 },
                        new PlatformInstance { Id = 10, Name = "Game Boy Color", Publisher = "Nintendo", Cost = 79.99 }
                    };
                    context.AddRange(platformList);
                    context.SaveChanges();
                    Console.WriteLine("Platform Data seeded");

            }
        }
    } 

}