using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.BLL.Interfaces
{
	public interface IUnitOfWork : IAsyncDisposable
	{
        public IEmployeeRepository EmployeeRepository { get; set; }
		Task<int> CompleteAsync();
	}
}
