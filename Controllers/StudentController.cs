using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUD.RequestResponse;
using StudentCRUD.Service;

namespace StudentCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _repository;
        public StudentController(IStudentService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("getstudents")]
        public async Task<IActionResult> GetStudents()
        {
            var res = await _repository.GetStudents();
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("getstudentbyid")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var res = await _repository.GetStudentById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("addstudent")]
        public async Task<IActionResult> AddStudent(Response student)
        {
            var res = await _repository.AddStudent(student);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("updatestudent")]
        public async Task<IActionResult> UpdateStudent(int id, Response student)
        {
            var res = await _repository.UpdateStudent(id, student);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpDelete]
        [Route("deletestudentbyid")]

        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var res = await _repository.DeleteStudentById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
