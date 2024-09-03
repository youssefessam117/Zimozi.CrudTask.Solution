using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.BLL.Interfaces;
using Zimozi.CrudTask.DAL.Data;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.BLL.Repositories
{
	internal class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public EmployeeRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(Employee entity)
			=> _dbContext.Add(entity);

		public void Delete(Employee entity)
			=> _dbContext.Remove(entity);

		public async Task<IReadOnlyList<Employee>> GetAllAsync()
		{
			return await _dbContext.Set<Employee>().AsNoTracking().ToListAsync();
		}

		public void Update(Employee entity)
			=> _dbContext.Update(entity);

		public async Task<Employee?> GetByIdAsync(int id)
		{
			return await _dbContext.Set<Employee>().FindAsync(id);
		}
	}
}
