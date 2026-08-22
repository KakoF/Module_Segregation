using Domain.Models.Imovel;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data.Context.Repositories
{
	public class ImovelRepository : IImovelRepository
	{
		private readonly AppDbContext _context;

		public ImovelRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Imovel?> GetByIdAsync(Guid id)
		{
			return await _context.Imoveis
				.Include(i => i.Proprietarios) // carrega proprietários junto
				.FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<IEnumerable<Imovel>> GetAllAsync()
		{
			return await _context.Imoveis
				.Include(i => i.Proprietarios)
				.ToListAsync();
		}

		public async Task AddAsync(Imovel imovel)
		{
			await _context.Imoveis.AddAsync(imovel);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Imovel imovel)
		{
			_context.Imoveis.Update(imovel);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var imovel = await GetByIdAsync(id);
			if (imovel != null)
			{
				_context.Imoveis.Remove(imovel);
				await _context.SaveChangesAsync();
			}
		}
	}
}
