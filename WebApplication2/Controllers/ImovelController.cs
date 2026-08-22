using Application.Services;
using Domain.Models.Imovel;
using Domain.Models.Proprietario;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Records.Imovel;

namespace WebApplication2.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ImovelController : ControllerBase
	{
		private readonly ILogger<ImovelController> _logger;
		private readonly ImobiliarioService _imobiliarioService;

		public ImovelController(ILogger<ImovelController> logger, ImobiliarioService imobiliarioService)
		{
			_logger = logger;
			_imobiliarioService = imobiliarioService;
		}

		[HttpGet("IPTU")]
		public async Task<Decimal?> CalcularIPTUAsync(Guid id)
		{
			var imovel = await _imobiliarioService.ObterImovelPorIdAsync(id);
			return imovel?.CalcularIPTU();
		}

		[HttpGet]
		public async Task<Imovel?> GetAsync(Guid id)
		{
			var imovel = await _imobiliarioService.ObterImovelPorIdAsync(id);
			return imovel;
		}

		[HttpPost]
		public async Task<Imovel> CreateAsync([FromBody] CreateImovelRequet request)
		{
			var imovel = Imovel.Create(request.TipoImovel, Guid.NewGuid(), request.Matricula, request.Valor, request.Endereco, request.Hectares);

			foreach (var proprietario in request.Proprietarios)
				imovel.AdicionarProprietario(Proprietario.Create(Guid.NewGuid(), proprietario.Nome, proprietario.Porcentagem));

			imovel = await _imobiliarioService.CriarImovelAsync(imovel);
			return imovel;
		}
	}
}
