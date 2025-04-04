using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfiles : Profile
    {
        public  PlatformProfiles()
        {
            //source -> Target
            CreateMap<PlatformCreateDto,PlatformInstance>();
            CreateMap<PlatformInstance,PlatformReadDto>();
        }

    }
}