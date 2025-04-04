using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PlatformService.Data;
using PlatformService.Data.Interface;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformInstanceRepo _platformInstanceRepo;


        public PlatformController(IMapper mapper, IPlatformInstanceRepo platformInstanceRepo)
        {
            _mapper = mapper;
            _platformInstanceRepo = platformInstanceRepo;
        }

        [HttpGet("GetAllPlatformInstances")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatformInstances()
        {
            IEnumerable<PlatformInstance> platInstances = _platformInstanceRepo.GetAllPlatformInstances();
            if (platInstances == null)
            {
                return NotFound("Platform Data is unavialable");
            }
            IEnumerable<PlatformReadDto> platReadDtos = _mapper.Map<IEnumerable<PlatformReadDto>>(platInstances);
            return Ok(platReadDtos);
        }



    }

}