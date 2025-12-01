using DevLearningAPI.Models.Dtos.StudantCourse;
using DevLearningAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly StudentCourseService _service;

        public StudentCourseController(StudentCourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentCourseResponseDto>>> GetAllStudentCoursesAsync()
        {
            try
            {
                var studentCourses = await _service.GetAllStudentCoursesAsync();

                if (studentCourses is null || !studentCourses.Any())
                {
                    return NotFound("No student-course relationships found.");
                }

                return Ok(studentCourses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("students/{studentId:guid}/courses/{courseId:guid}")]
        public async Task<ActionResult> CreateStudentCourseAsync(CreateStudantCourseDto studentCourse,Guid studentId, Guid courseId)
        {
            try
            {

                await _service.CreateStudentCourseAsync(studentCourse,studentId, courseId);
                return Created("Student enrolled with sucess!", null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update-progress/students/{studentId}/courses/{courseId}/progress/{minutesWatched}")]
        public async Task<ActionResult> UpdateCourseProgressAsync(Guid studentId, Guid courseId, int minutesWatched)
        {
            try
            {
                if (!await _service.GetRelationStudentCourseAsync(studentId, courseId))
                    return BadRequest();

                await _service.UpdateCourseProgressAsync(studentId, courseId, minutesWatched);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the course progress.");
            }

        }

        [HttpPut("update-favorite/students/{studentId:guid}/courses/{courseId:guid}/favorite")]
        public async Task<ActionResult> UpdateFavoriteStudentCourse(Guid studentId, Guid courseId)
        {
            try
            {

                var existsRelationShip = await _service.GetRelationStudentCourseAsync(studentId, courseId);
                if (!await _service.GetRelationStudentCourseAsync(studentId, courseId))
                    return BadRequest();

                var newValue = await _service.UpdateFavoriteStudentCourse(studentId, courseId);
                if (newValue == null)
                    return NotFound(new { message = "Student-Course relationship not found." });

                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the favorite status.");
            }

        }
    }
}