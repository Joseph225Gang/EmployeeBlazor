using EmployeeBlazor.Api2.Repository;
using EmployeeBlazor.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBlazor.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAllEmployees());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById(int employeeId)
        {
            return Ok(_employeeRepository.GetEmployeeById(employeeId));
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            var createdEmployee = _employeeRepository.AddEmployee(employee);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            var createdEmployee = _employeeRepository.UpdateEmployee(employee);

            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if (employeeId == 0)
                return BadRequest();
            _employeeRepository.DeleteEmployee(employeeId);

            return NoContent();//success
        }
    }
}
