using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class PlatformInstance
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