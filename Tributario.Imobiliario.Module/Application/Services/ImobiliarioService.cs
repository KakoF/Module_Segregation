using Domain.Models.Imovel;
using Domain.Models.Imovel.Enums;
using Domain.Models.Proprietario;
using Domain.Repositories;

namespace Application.Services
{
	public class ImobiliarioService
	{
		private readonly IImovelRepository _imovelRepository;
		private readonly IProprietarioRepository _proprietarioRepository;

		public ImobiliarioService(IImovelRepository imovelRepository, IProprietarioRepository proprietarioRepository)
		{
			_imovelRepository = imovelRepository;
			_proprietarioRepository = proprietarioRepository;
		}

		// Criar um novo imóvel
		public async Task<Imovel> CriarImovelAsync(TipoImovel tipo, Guid id, string matricula, decimal valor, string? endereco = null, decimal? hectares = null)
		{
			var imovel = Imovel.Create(tipo, id, matricula, valor, endereco, hectares);
			await _imovelRepository.AddAsync(imovel);
			return imovel;
		}

		// Buscar imóvel por Id
		public async Task<Imovel?> ObterImovelPorIdAsync(Guid id)
		{
			return await _imovelRepository.GetByIdAsync(id);
		}

		// Adicionar proprietário a um imóvel
		public async Task AdicionarProprietarioAsync(Guid imovelId, Guid proprietarioId)
		{
			var imovel = await _imovelRepository.GetByIdAsync(imovelId);
			var proprietario = await _proprietarioRepository.GetByIdAsync(proprietarioId);

			if (imovel == null || proprietario == null)
				throw new InvalidOperationException("Imóvel ou proprietário não encontrado.");

			imovel.AdicionarProprietario(proprietario);
			await _imovelRepository.UpdateAsync(imovel);
		}

		// Criar proprietário
		public async Task<Proprietario> CriarProprietarioAsync(Guid id, string nome, double porcentagem)
		{
			var proprietario = Proprietario.Create(id, nome, porcentagem);
			await _proprietarioRepository.AddAsync(proprietario);
			return proprietario;
		}

		// Listar todos os imóveis
		public async Task<IEnumerable<Imovel>> ListarImoveisAsync()
		{
			return await _imovelRepository.GetAllAsync();
		}

		// Listar todos os proprietários
		public async Task<IEnumerable<Proprietario>> ListarProprietariosAsync()
		{
			return await _proprietarioRepository.GetAllAsync();
		}
	}

}
