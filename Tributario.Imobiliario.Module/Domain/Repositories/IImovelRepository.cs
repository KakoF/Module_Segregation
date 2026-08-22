using Domain.Models.Imovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IImovelRepository
	{
		Task<Imovel?> GetByIdAsync(Guid id);
		Task<IEnumerable<Imovel>> GetAllAsync();
		Task AddAsync(Imovel imovel);
		Task UpdateAsync(Imovel imovel);
		Task DeleteAsync(Guid id);
	}
}
