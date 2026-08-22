using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<Produto> Produtos { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	}
}
