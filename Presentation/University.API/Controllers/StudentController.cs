using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.API.Models;
using University.Core.Domain;
using University.Data;
using University.Services.Students;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace University.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet("GetStudentById/{id}")]
        [ProducesResponseType(typeof(StudentModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentModel>> GetStudentById(int id)
        {
           var temp = await _studentService.GetStudentById(id);
            var result = _mapper.Map<StudentModel>(temp);

           if(result != null)
            {
                return Ok(result);
            }
            return NotFound("invalid get student");
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody] StudentModel studentModel)
        {
            try
            {
                var student = _mapper.Map<Student>(studentModel);
                _studentService.InsertStudent(student);

                return Ok();
            }
            catch
            {
                return BadRequest("invalid get student");
            }
        }
    }
}
