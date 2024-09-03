using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.BLL.Interfaces;
using Zimozi.CrudTask.BLL.Services;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.Test
{
	public class EmployeeServiceTests
	{
		private readonly Mock<IUnitOfWork> _repositoryMock;
		private readonly IEmployeeService _employeeService;
		public EmployeeServiceTests()
		{
			_repositoryMock = new Mock<IUnitOfWork>();
			_employeeService = new EmployeeService(_repositoryMock.Object);
		}

		[Fact]
		public async Task ShouldReturnAllEmployees()
		{
			// Arrange
			var employees = new List<Employee>
		{
			new Employee { Id = 1, Name = "John", Department = "IT", Salary = 5000 },
			new Employee { Id = 2, Name = "Jane", Department = "HR", Salary = 4500 }
		};
			_repositoryMock.Setup(repo => repo.EmployeeRepository.GetAllAsync()).ReturnsAsync(employees);

			// Act
			var result = await _employeeService.GetEmployeesAsync();

			// Assert
			result.Should().HaveCount(2);
			result.Should().Contain(employees);
		}



		[Fact]
		public async Task AddEmployeeAsync_WithValidEmployee()
		{
			// Arrange
			var employee = new Employee { Id = 1, Name = "John", Department = "IT", Salary = 5000 };

			// Act
			await _employeeService.AddNewEmployee(employee);

			// Assert
			_repositoryMock.Verify(repo => repo.EmployeeRepository.Add(employee), Times.Once);
		}

		[Fact]
		public async Task AddEmployeeAsync_WithNegativeSalary()
		{
			// Arrange
			var employee = new Employee { Id = 1, Name = "John", Department = "IT", Salary = -1000 };

			// Act
			Func<Task> act = async () => await _employeeService.AddNewEmployee(employee);

			// Assert
			await act.Should().ThrowAsync<ArgumentException>().WithMessage("Salary must be a positive number.");
		}

		[Fact]
		public async Task DeleteEmployeeAsync_WithValidId()
		{
			// Arrange
			var employeeId = 1;

			// Act
			await _employeeService.DeleteEmployee(employeeId);

			// Assert
			//_repositoryMock.Verify(repo => repo.EmployeeRepository.Delete(/*employeeId*/), Times.Once);
		}

	}


}
