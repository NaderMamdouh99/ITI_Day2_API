using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDay2.Models;

namespace WebApiDay2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly appContext appContext;

        public DepartmentController(appContext _appContext) 
        {
            appContext = _appContext;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Department dept = appContext.Departments.Include(d=>d.Employees).FirstOrDefault(d=>d.Id==id);
            if (dept != null)
            {
                DepartmentDataWithStudentNameDTO dto = new DepartmentDataWithStudentNameDTO();
                dto.Id = dept.Id;
                dto.Name = dept.Name;
                foreach (var emp in dept.Employees)
                {
                    dto.Employees.Add(emp);
                }

                return Ok(dto);
            }
            return BadRequest("Not Found !!");
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> deps = appContext.Departments.Include(d => d.Employees).ToList();
            if(deps !=null)
            {
                List<DepartmentDataWithStudentNameDTO> dtoList = new List<DepartmentDataWithStudentNameDTO>();
                foreach (var dep in deps)
                {
                    DepartmentDataWithStudentNameDTO dto = new DepartmentDataWithStudentNameDTO();
                    dto.Id = dep.Id;
                    dto.Name = dep.Name;
                    foreach (var emp in dep.Employees)
                    {
                        dto.Employees.Add(emp);
                    }
                    dtoList.Add(dto);
                }
                return Ok(dtoList);
            }
            return BadRequest("Not Found!!");

        }



    }
}
