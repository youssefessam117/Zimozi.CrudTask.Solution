using System.ComponentModel.DataAnnotations;

namespace Zimozi.CrudTaskPL.Dtos
{
	public class EmployeeDto
	{
		public int EmployeeID { get; set; }
		[Required]
		[MaxLength(100, ErrorMessage = "Max Length of Name is 100 Chars")]
		public string Name { get; set; }

		[Required]
		[MaxLength(100, ErrorMessage = "Max Length of Name is 100 Chars")]
		public string Department { get; set; }

		[DataType(DataType.Currency)]
		[Range(1, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
		public decimal Salary { get; set; }
	}
}
