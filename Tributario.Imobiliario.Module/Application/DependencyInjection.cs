using infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection ConfigureImobiliarioModule(this IServiceCollection services, string connectionString)
		{
			services.ConfigureImobiliarioInfrastructure(connectionString);
			services.ConfigureImobiliarioApplication();

			return services;
		}
	}
}
