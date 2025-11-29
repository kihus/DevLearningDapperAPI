using DevLearningAPI.Controllers.Interfaces;
using DevLearningAPI.Models.Dtos.CareerItem;
using DevLearningAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerItemController : ControllerBase, ICareerItemController
    {
        #region ServiceDependencyInjection
        private readonly ICareerItemService _careerItemService;

        private readonly ICareerService _careerService;

        private readonly ICourseService _courseService;

        public CareerItemController(ICareerItemService careerItemService, ICareerService careerService, ICourseService courseService)
        {
            _careerItemService = careerItemService;
            _careerService = careerService;
            _courseService = courseService;
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult> CreateCareeritemAsync(CreateCareerItemDto careerItem)
        {
            try
            {
                var careerFound = await _careerService.GetCareerByIdAsync(careerItem.CareerId);
                var courseFound =  await _courseService.GetCourseByIdAsync(careerItem.CourseId);

                if (careerFound is null || careerFound.Active is false)
                    return NotFound("Career does not exist or is inactive!");

                if (courseFound is null || courseFound.Active is false)
                    return NotFound("Course does not exist or is inactive!");

                await _careerItemService.CreateCareeritemAsync(careerItem);
                return Created();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
