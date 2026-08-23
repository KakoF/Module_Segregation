using Tributario.Atendimento.Module.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Tributario.Atendimento.Module.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection ConfigureAtendimentoModule(this IServiceCollection services, string connectionString)
		{
			services.ConfigureAtendimentoInfrastructure(connectionString);
			services.ConfigureAtendimentoApplication();

			return services;
		}
	}
}
