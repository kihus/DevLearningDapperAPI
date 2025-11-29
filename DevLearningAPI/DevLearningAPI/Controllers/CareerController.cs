using DevLearningAPI.Controllers.Interfaces;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Career;
using DevLearningAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase, ICareerController
    {
        #region ServiceDependencyInjection
        private readonly ICareerService _careerService;

        public CareerController(ICareerService careerService)
        {
            this._careerService = careerService;
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult> CreateCareerAsync(CreateCareerDto career)
        {
            try
            {
                await _careerService.CreateCareerAsync(career);
                return Created();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
           
        }

        [HttpGet]
        public async Task<ActionResult<List<CareerResponseDto>>> GetAllCareersAsync()
        {
            try
            {
                var careers = await _careerService.GetAllCareersAsync();

                if (careers is null)
                    return NotFound("Register not found!");

                return Ok(careers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpGet("{careerId}")]
        public async Task<ActionResult<CareerResponseDto>> GetCareerByIdAsync(Guid careerId)
        {
            try
            {
                var career = await _careerService.GetCareerByIdAsync(careerId);

                if (career is null)
                    return NotFound("Register not found!");

                return Ok(career);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPut("{careerId}")]
        public async Task<ActionResult> UpdateCareerAsync(Guid careerId,UpdateCareerDto careerRequest)
        {
            try
            {
                if (await _careerService.GetCareerByIdAsync(careerId) is null)
                    return NotFound("Register not found!");

                await _careerService.UpdateCareerAsync(careerId, careerRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{careerId}")]
        public async Task<ActionResult> ChangeActiveAsync(Guid careerId)
        {
            try
            {
                if (await _careerService.GetCareerByIdAsync(careerId) is null)
                    return NotFound("Register not found!");

                await _careerService.ChangeActiveAsync(careerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
