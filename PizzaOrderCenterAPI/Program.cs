using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Services;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		ConfigureServices(builder.Services);
		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

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

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddScoped<IPizzaOrderCenterDbContext, PizzaOrderCenterDbContext>();
		services.AddTransient<IPizzeriaService, PizzeriaService>();

		services.AddDbContext<PizzaOrderCenterDbContext>(
			options => options.UseSqlite(@"Data Source=DataAccess\PizzaOrderCenterDbContext.db"));
	}
}