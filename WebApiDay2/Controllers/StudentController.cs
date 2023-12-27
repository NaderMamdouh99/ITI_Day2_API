using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDay2.Models;

namespace WebApiDay2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly appContext appContext;

        public StudentController(appContext _appContext)
        {
            appContext = _appContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> emps = appContext.Employees.Include(e => e.Department).ToList();
            return Ok(emps);
        }
    }
}
