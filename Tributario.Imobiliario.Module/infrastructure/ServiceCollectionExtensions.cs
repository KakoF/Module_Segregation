using Domain.Repositories;
using infrastructure.Data.Context;
using infrastructure.Data.Context.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureImobiliarioInfrastructure(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddScoped<IImovelRepository, ImovelRepository>();
			services.AddScoped<IProprietarioRepository, ProprietarioRepository>();


			using (var provider = services.BuildServiceProvider())
			using (var scope = provider.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				db.Database.Migrate();
			}

			return services;
		}
	}
}
