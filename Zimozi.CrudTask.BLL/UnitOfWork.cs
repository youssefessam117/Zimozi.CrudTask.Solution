using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.BLL.Interfaces;
using Zimozi.CrudTask.BLL.Repositories;
using Zimozi.CrudTask.DAL.Data;

namespace Zimozi.CrudTask.BLL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;
		public IEmployeeRepository EmployeeRepository { get; set; }


		public UnitOfWork(ApplicationDbContext dbContext) 
		{
			_dbContext = dbContext;
			EmployeeRepository = new EmployeeRepository(_dbContext);
		}


		public async Task<int> CompleteAsync()
			=> await _dbContext.SaveChangesAsync();

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}
	}
}
