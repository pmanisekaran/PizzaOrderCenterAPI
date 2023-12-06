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
		ConfigurationManager configurationManager = builder.Configuration; // allows both to access and to set up the config
		ConfigureServices(builder.Services, configurationManager);


		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		//builder.Services.AddCors(options =>
		//{
		//	options.AddPolicy(name: MyAllowSpecificOrigins,
		//					  policy =>
		//					  {
		//						  policy.WithOrigins("http://localhost:3000",
		//											  "*");
		//					  });
		//});

		builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
		{
			builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
		}));


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

		app.UseCors("MyPolicy");
		app.InitialiseInMemoryDatabase(configurationManager); //extension method
		app.Run();
		
			 
	}

	private static void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager )
	{
		var connectionString = configurationManager.GetConnectionString("PizzaOrderCenterDbConnectionString");

		var useInMemoryDB = Convert.ToBoolean( configurationManager.GetRequiredSection("PizzaOrderCenterAppSettings")["UseInMemoryDatabase"]);

		if (useInMemoryDB)
		{
			services.AddDbContext<PizzaOrderCenterDbContext>(
				options => options.UseInMemoryDatabase("PizzaOrderCenterDbContext.db"));
			
		}
		else
		{
			services.AddDbContext<PizzaOrderCenterDbContext>(
				options => options.UseSqlite(connectionString));
		}

		services.AddScoped<IPizzaOrderCenterDbContext, PizzaOrderCenterDbContext>();
		services.AddTransient<IPizzeriaService, PizzeriaService>();
		services.AddTransient<IPizzeriaMenuService, PizzeriaMenuService>();
		services.AddTransient<IPizzaToppingService, PizzaToppingService>();
		services.AddTransient<IPizzaOrderService, PizzaOrderService>();


	}


}