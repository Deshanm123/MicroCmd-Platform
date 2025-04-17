using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PlatformService.Data;
using PlatformService.Data.Interface;
using PlatformService.Dtos;
using PlatformService.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [HttpGet]
        [Route("GetPlatformById/{id}",Name = "GetPlatformById")]
         
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
           PlatformInstance plt = _platformInstanceRepo.GetPlatformById(id);
           if(plt == null)
           {
                return BadRequest("The requested platform is not available");
           }
            return Ok(_mapper.Map<PlatformReadDto>(plt));
        }

        [HttpPost]
        [Route("CreatePlatform")]
        public IActionResult CreatePlatform([FromBody] PlatformCreateDto pltCreate)
        {
            PlatformInstance plt =  _mapper.Map<PlatformInstance>(pltCreate);
           //check the required inputs are present
            if (TryValidateModel(plt))
            {
                try
                { 
                    //Id should be a integer check
                    if(plt.Id == 0)
                        throw new ArgumentException("The provided Id is not a valid Integer");
                    
                    _platformInstanceRepo.CreatePlatform(plt);

                    //if not saved throw an error
                    if(_platformInstanceRepo.SaveChanges())
                    {
                        //201 Created: //nameof(actionname you wanna go/ route name)
                        return CreatedAtRoute(nameof(GetPlatformById),new{id =plt.Id},plt);
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest("Error "+ex.Message.ToString());
                }
            }
            return BadRequest("Model is invalid. Please enter all the required information ");
        }


    }

}