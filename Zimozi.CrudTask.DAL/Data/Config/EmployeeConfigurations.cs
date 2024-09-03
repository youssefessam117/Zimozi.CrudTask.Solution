using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Zimozi.CrudTask.DAL.Models;

namespace Zimozi.CrudTask.DAL.Data.Config
{
	internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.Property(emp => emp.Name).IsRequired().HasColumnType("varchar").HasMaxLength(100);
			builder.Property(emp => emp.Department).IsRequired().HasColumnType("varchar").HasMaxLength(100);
			builder.Property(emp => emp.Salary).HasColumnType("decimal(12,2)");

		}
	}
}
