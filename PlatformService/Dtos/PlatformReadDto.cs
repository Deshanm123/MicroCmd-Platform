namespace PlatformService.Dtos
{
    public class PlatformReadDto
    {
        public int Id{set;get;}
        public string Name{set;get;} = "unknown platform";
        public string Publisher{set;get;}= "unknown publisher";
        public double Cost{set;get;}
    }
}