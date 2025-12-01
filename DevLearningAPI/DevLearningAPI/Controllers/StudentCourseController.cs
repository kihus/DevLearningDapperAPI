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

        [HttpPost("students/courses/")]
        public async Task<ActionResult> CreateStudentCourseAsync(CreateStudentCourseDto studentCourse)
        {
            try
            {

                await _service.CreateStudentCourseAsync(studentCourse);
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

        [HttpPut("update-favorite/students/courses/favorite")]
        public async Task<ActionResult> UpdateFavoriteStudentCourse(CreateStudentCourseDto studentCourse)
        {
            try
            {
                if (!await _service.GetRelationStudentCourseAsync(studentCourse.StudentId, studentCourse.CourseId))
                    return BadRequest();

                var newValue = await _service.UpdateFavoriteStudentCourse(studentCourse);
                if (newValue == null)
                    return NotFound();

                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the favorite status.");
            }

        }
    }
}