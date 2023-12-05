using System.Runtime.CompilerServices;

namespace PizzaOrderCenterAPI.DataAccess
{
	public static class DBInitialiser
	{
		public static void InitialiseInMemoryDatabase(this IApplicationBuilder app, ConfigurationManager configurationManager)
		{
			using var serviceScope = app.ApplicationServices
										.GetService<IServiceScopeFactory>()
										.CreateScope();
			var context = serviceScope.ServiceProvider.GetRequiredService<PizzaOrderCenterDbContext>();
			context.Database.EnsureCreated();
		}
	}
}
