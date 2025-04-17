using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class PlatformInstance
    {
        [Key]
        [Required]
        public int Id{set;get;}

        [Required]
        public string? Name { set; get; }

        [Required]
        public string? Publisher { set; get; }
        
        [Required]
        public double Cost{set;get;}
    }

}