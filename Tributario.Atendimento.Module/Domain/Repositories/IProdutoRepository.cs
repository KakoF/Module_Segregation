using Domain.Entities;

namespace Domain.Repositories
{
	public interface IProdutoRepository
	{
		Task<Produto?> GetAsync(Guid id);
		Task AddAsync(Produto produto);
	}
}
