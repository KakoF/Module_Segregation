using Tributario.Imobiliario.Module.infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Tributario.Imobiliario.Module.Application
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
