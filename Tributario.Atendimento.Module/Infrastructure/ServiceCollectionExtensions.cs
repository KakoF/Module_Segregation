using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureAtendimentoInfrastructure(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddScoped<IProdutoRepository, ProdutoRepository>();


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

