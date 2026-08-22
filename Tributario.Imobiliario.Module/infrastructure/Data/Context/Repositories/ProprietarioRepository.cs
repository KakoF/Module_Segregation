using Domain.Models.Proprietario;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data.Context.Repositories
{
	public class ProprietarioRepository : IProprietarioRepository
	{
		private readonly AppDbContext _context;

		public ProprietarioRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Proprietario?> GetByIdAsync(Guid id)
		{
			return await _context.Proprietarios.FindAsync(id);
		}

		public async Task<IEnumerable<Proprietario>> GetAllAsync()
		{
			return await _context.Proprietarios.ToListAsync();
		}

		public async Task AddAsync(Proprietario proprietario)
		{
			await _context.Proprietarios.AddAsync(proprietario);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Proprietario proprietario)
		{
			_context.Proprietarios.Update(proprietario);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var proprietario = await GetByIdAsync(id);
			if (proprietario != null)
			{
				_context.Proprietarios.Remove(proprietario);
				await _context.SaveChangesAsync();
			}
		}
	}
}
