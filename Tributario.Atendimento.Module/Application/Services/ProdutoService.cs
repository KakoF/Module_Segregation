
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
	public class ProdutoService
	{
		private readonly IProdutoRepository _repo;

		public ProdutoService(IProdutoRepository repo)
		{
			_repo = repo;
		}

		public async Task<Guid> CreateAsync(string nome)
		{
			var produto = new Produto(nome);
			await _repo.AddAsync(produto);
			return produto.Id;
		}
	}
}
