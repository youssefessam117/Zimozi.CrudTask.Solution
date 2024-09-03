using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zimozi.CrudTask.BLL.Interfaces;
using Zimozi.CrudTask.DAL.Errors;
using Zimozi.CrudTask.DAL.Models;
using Zimozi.CrudTaskPL.Dtos;

namespace Zimozi.CrudTaskPL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			this.employeeService = employeeService;
		}

		// GET: /Employees
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
		{
			var employees = await employeeService.GetEmployeesAsync();
			return Ok(employees);
		}

		[ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
		[HttpPost]
		public async Task<ActionResult<Employee>> AddNewEmployee(EmployeeDto employeeDto)
		{
			Employee employee = new Employee()
			{
				Department = employeeDto.Department,
				Name = employeeDto.Name,
				Salary = employeeDto.Salary,
			};

			var isEmployee = await employeeService.AddNewEmployee(employee);

			if (isEmployee == null)
			{
				return BadRequest(new ApiResponse(400));
			}
			return Ok(employeeDto);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateEmployee([FromBody]EmployeeDto employeeDto, [FromRoute] int id)
		{
			if (id != employeeDto.EmployeeID)
			{
				return BadRequest(new ApiResponse(400));
			}

			var employee = new Employee()
			{
				Department = employeeDto.Department,
				Name = employeeDto.Name,
				Salary = employeeDto.Salary,
			};

			var updatedEmp = await employeeService.UpdateEmployee(employee, id);

			if (updatedEmp <= 0 )
			{
				return BadRequest(new ApiResponse(400));
			}

			return Ok(employee);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEmployee(int id)
		{
			var result = await employeeService.DeleteEmployee(id);

			if (result == 0 ) return BadRequest(new ApiResponse(400));

			return Ok();
		}

	}
}
