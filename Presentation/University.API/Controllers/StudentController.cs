using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.Core.Domain;
using University.Data;
using University.Services.Students;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
           var result = await _studentService.GetStudentById(id);
           if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("invalid get student");
        }
    }
}
