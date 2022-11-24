using BlazorScrumAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorScrumAPI
{
	public static class MigrationManager
	{
		public static IHost MigrateDatabase(this IHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				using (var context = scope.ServiceProvider.GetRequiredService<ScrumBoardContext>())
				{
					try
					{
						context.Database.Migrate();
					}
					catch (Exception )
					{
						throw;
					}
				}
			}
			return host;
		}
	}
}
