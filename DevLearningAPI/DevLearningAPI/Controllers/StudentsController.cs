using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Student;
using DevLearningAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentResponseDto>>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _service.GetAllStudentsAsync();

                if (students.Count is 0)
                    return NotFound("Register not found!");

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudentAsync(CreateStudentDto studentCreate)
        {

            try
            {
                await _service.CreateStudentAsync(studentCreate);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update-email/{id}")]
        public async Task<ActionResult> UpdateEmailStudentAsync(Guid id, UpdateStudentEmailDto dtoEmail)
        {
            try
            {
                if (await _service.GetStudentByIdAsync(id) is null)
                    return NotFound("Student not found!");

                await _service.UpdateEmailStudentAsync(id, dtoEmail);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("update-phone/{id}")]
        public async Task<ActionResult> UpdatePhoneStudentAsync(Guid id, UpdateStudentPhoneDto dtoPhone)
        {
            try
            {
                if (await _service.GetStudentByIdAsync(id) is null)
                    return NotFound("Student not found!");

                await _service.UpdatePhoneStudentAsync(id, dtoPhone);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentAsync(Guid id)
        {
            try
            {
                if (await _service.GetStudentByIdAsync(id) is null)
                    return NotFound("Student not found!");

                await _service.DeleteStudentAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDto>> GetStudentByIdAsync(Guid id)
        {
            try
            {
                var student = await _service.GetStudentByIdAsync(id);

                if (student is null)
                    return NotFound("Student not found!");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }

}

