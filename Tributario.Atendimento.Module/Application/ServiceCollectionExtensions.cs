using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureAtendimentoApplication(this IServiceCollection services)
		{
			services.AddScoped<ProdutoService>();
			return services;
		}
	}
}
