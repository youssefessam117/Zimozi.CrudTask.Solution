using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zimozi.CrudTask.DAL.Models
{
	public class Employee : ModelBase
	{
        public string Name { get; set; }

        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
