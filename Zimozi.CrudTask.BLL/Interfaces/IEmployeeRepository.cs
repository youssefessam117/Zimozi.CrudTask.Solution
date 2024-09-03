using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.BLL.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<IReadOnlyList<Employee>> GetAllAsync();

		void Add(Employee entity);

		void Update(Employee entity);

		void Delete(Employee entity);

		Task<Employee?> GetByIdAsync(int id);
	}
}
