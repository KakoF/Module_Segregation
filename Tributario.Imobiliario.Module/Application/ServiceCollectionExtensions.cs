using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Tributario.Imobiliario.Module.Application
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureImobiliarioApplication(this IServiceCollection services)
		{
			services.AddScoped<ImobiliarioService>();
			return services;
		}
	}
}
