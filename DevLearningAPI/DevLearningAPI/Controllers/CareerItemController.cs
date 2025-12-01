using DevLearningAPI.Controllers.Interfaces;
using DevLearningAPI.Models;
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
                var courseFound = await _courseService.GetCourseByIdAsync(careerItem.CourseId);

                if (careerFound is null || careerFound.Active is false)
                    return NotFound("Career does not exist or is inactive!");

                if (courseFound is null || courseFound.Active is false)
                    return NotFound("Course does not exist or is inactive!");

                await _careerItemService.CreateCareeritemAsync(careerItem);
                return Created();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCareerItemAsync(UpdateCareerItemDto careerItem)
        {
            try
            {
                if (careerItem.CareerId == Guid.Empty || careerItem.CourseId == Guid.Empty)
                    return BadRequest("CareerId e CourseId precisam ser informados.");

                var careerItemFound = await _careerItemService
                    .GetCareerItemByCareerCourseIdAsync(careerItem.CareerId, careerItem.CourseId);

                if (careerItemFound is null)
                    return NotFound("Registro não encontrado!");

                await _careerItemService.UpdateCareerItemAsync(careerItem.CareerId, careerItem.CourseId, careerItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Career/{careerId}")]
        public async Task<ActionResult> DeleteAllCareerItemByCareerIdAsync(Guid careerId)
        {
            var careerItemFound = await _careerItemService.GetCareerItemByCareerIdAsync(careerId);

            if (careerItemFound is null)
                return NotFound("Register not found!");

            await _careerItemService.DeleteAllCareerItemByCareerIdAsync(careerId);
            return NoContent();
        }

        [HttpDelete("Course/{courseId}")]
        public async Task<ActionResult> DeleteAllCareerItemByCourseIdAsync(Guid courseId)
        {
            var careerItemFound = await _careerItemService.GetCareerItemByCourseIdAsync(courseId);

            if (careerItemFound is null)
                return NotFound("Register not found!");

            await _careerItemService.DeleteAllCareerItemByCourseIdAsync(courseId);
            return NoContent();
        }

        [HttpDelete("CareerCourse/{careerId}/{courseId}")]
        public async Task<ActionResult> DeleteCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId)
        {
            var careerItemFound = await _careerItemService.GetCareerItemByCareerCourseIdAsync(careerId, courseId);

            if (careerItemFound is null)
                return NotFound("Register not found!");

            await _careerItemService.DeleteCareerItemByCareerCourseIdAsync(careerId, courseId);
            return NoContent();
        }


    }
}
