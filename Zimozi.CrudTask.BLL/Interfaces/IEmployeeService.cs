using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.BLL.Interfaces
{
	public interface IEmployeeService
	{
		Task<IReadOnlyList<Employee>> GetEmployeesAsync();

		Task<Employee?> AddNewEmployee(Employee employee);

		Task<int> DeleteEmployee(int id);

		Task<int> UpdateEmployee(Employee employee, int employeeId);
	}
}
