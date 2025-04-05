namespace PlatformService.Dtos
{
    //Dtos are strictly data transfer objects only
    //cannnot assign values in between or cannot be used for the model validation
    public class PlatformReadDto
    {
        public int Id{set;get;}
        public string? Name {set;get;} 
        public string? Publisher{set;get;}
        public double Cost{set;get;}
    }
}