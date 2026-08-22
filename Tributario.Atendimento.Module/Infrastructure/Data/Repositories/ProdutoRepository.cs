using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories
{
	internal class ProdutoRepository : IProdutoRepository
	{
		private readonly AppDbContext _context;

		public ProdutoRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Produto?> GetAsync(Guid id) =>
			await _context.Produtos.FindAsync(id);

		public async Task AddAsync(Produto produto)
		{
			_context.Produtos.Add(produto);
			await _context.SaveChangesAsync();
		}
	}
}
