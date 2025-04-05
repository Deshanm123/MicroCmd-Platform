using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    //Dto should not have any model validationthey are strictly for data transfer only
    public class PlatformCreateDto
    {
        public int Id{set;get;}

        public string? Name{set;get;} 
        
        public string? Publisher{set;get;}
        
        public double Cost{set;get;}
    }
}