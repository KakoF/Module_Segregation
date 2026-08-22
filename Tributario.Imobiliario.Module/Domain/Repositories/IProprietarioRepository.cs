using Domain.Models.Proprietario;

namespace Domain.Repositories
{
	public interface IProprietarioRepository
	{
		Task<Proprietario?> GetByIdAsync(Guid id);
		Task<IEnumerable<Proprietario>> GetAllAsync();
		Task AddAsync(Proprietario proprietario);
		Task UpdateAsync(Proprietario proprietario);
		Task DeleteAsync(Guid id);
	}
}
