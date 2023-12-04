using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaOrderCenterAPI;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;
using System;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
		ConfigureServices(builder.Services, configuration);


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

	private static void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager )
	{
		var settingsSection = configurationManager.GetConnectionString("PizzaOrderCenterDbConnectionString");

		//services.AddDbContext<PizzaOrderCenterDbContext>(
		//	options => options.UseInMemoryDatabase("PizzaOrderCenterDbContext.db"));

		services.AddDbContext<PizzaOrderCenterDbContext>(
			options => options.UseSqlite(@"Data Source=DataAccess\PizzaOrderCenterDbContext.db"));

		services.AddScoped<IPizzaOrderCenterDbContext, PizzaOrderCenterDbContext>();
		services.AddTransient<IPizzeriaService, PizzeriaService>();

	}


}