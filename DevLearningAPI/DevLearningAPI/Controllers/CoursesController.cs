using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly CourseService _service;

		public CoursesController(CourseService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<CourseResponseDto>>> GetAllCourses()
		{
			try
			{
				var courses = await _service.GetAllCoursesAsync();

				if (courses.Count is 0)
					return NotFound("Register not found!");

				return Ok(courses);
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CourseResponseDto>> GetCourseById(Guid id)
		{
			try
			{
				var course = await _service.GetCourseByIdAsync(id);

				if (course is null)
					return NotFound("Register not found!");

				return Ok(course);
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult> CreateCourse(CreateCourseDto course)
		{
			try
			{
				await _service.CreateCourseAsync(course);
				return Created();
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateCourse(Guid id, UpdateCourseDto course)
		{
			try
			{
				if (await _service.GetCourseByIdAsync(id) is null)
					return NotFound("Register not found!");

				await _service.UpdateCourseAsync(id, course);
				return Ok();
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		[HttpPut("active/{id}")]
        public async Task<ActionResult> ActiveCourseAsync(Guid id)
		{
			try
			{
                var situation = await _service.ActiveCourseAsync(id);

				if (situation is null)
					return NotFound("Register not found!");

				if (situation == true)
					return Ok(new { message = "Course is already active!", active = true });

                return Ok(new { message = "Course is already active!", active = situation });
            }
			catch (Exception ex)
			{
                return Problem(ex.Message);
            }
        }


        [HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCourse(Guid id)
		{
			try
			{
				if (await _service.GetCourseByIdAsync(id) is null)
					return NotFound("Register not found!");

				await _service.DeleteCourseAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}
	}
}
