
using Microsoft.EntityFrameworkCore;
using Zimozi.CrudTask.BLL;
using Zimozi.CrudTask.BLL.Interfaces;
using Zimozi.CrudTask.BLL.Services;
using Zimozi.CrudTask.DAL.Data;

namespace Zimozi.CrudTaskPL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<ApplicationDbContext>(option =>
			{
				option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
			builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));



			var app = builder.Build();


			#region apply all pending migrations [update-database]

			using var scop = app.Services.CreateScope();

			var services = scop.ServiceProvider;

			var _dbContext = services.GetRequiredService<ApplicationDbContext>();// ask clr for creating object from dbcontext explicitly 

			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
			var logger = loggerFactory.CreateLogger<Program>();

			try
			{
				await _dbContext.Database.MigrateAsync();// update database 
			}
			catch (Exception ex)
			{

				logger.LogError(ex.StackTrace, "an error has been occured during apply migration");
			}
			#endregion

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
