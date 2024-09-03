using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.BLL.Interfaces;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.BLL.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IUnitOfWork unitOfWork;

		public EmployeeService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<Employee?> AddNewEmployee(Employee employee)
		{
			unitOfWork.EmployeeRepository.Add(employee);
			var result = await unitOfWork.CompleteAsync();
			if (result <= 0) return null;

			return employee;
		}

		public async Task<int> DeleteEmployee(int id)
		{
			var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id);
			if (employee != null)
			{
				unitOfWork.EmployeeRepository.Delete(employee);
			}
			return await unitOfWork.CompleteAsync();
		}
		public async Task<IReadOnlyList<Employee>> GetEmployeesAsync()
			=> await unitOfWork.EmployeeRepository.GetAllAsync();

		public async Task<int> UpdateEmployee(Employee employee, int employeeId)
		{
			var existEmployee = await unitOfWork.EmployeeRepository.GetByIdAsync(employeeId);
			if (existEmployee != null)
			{
				existEmployee.Name = employee.Name;
				existEmployee.Department = employee.Department;
				existEmployee.Salary = employee.Salary;
				unitOfWork.EmployeeRepository.Update(existEmployee);
			}

			return await unitOfWork.CompleteAsync();
		}

	}
}
