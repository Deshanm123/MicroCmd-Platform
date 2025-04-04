using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatformCreateDto
    {
         [Key]
        public int Id{set;get;}

        [Required]
        public string Name{set;get;} = "unknown platform";
        
        [Required]
        public string Publisher{set;get;}= "unknown publisher";
        
        [Required]
        public double Cost{set;get;}
    }
}