
using Domain.Models.Imovel;
using Domain.Models.Proprietario;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace infrastructure.Data.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<Imovel> Imoveis { get; set; }
		public DbSet<ImovelUrbano> ImoveisUrbanos { get; set; }
		public DbSet<ImovelRural> ImoveisRurais { get; set; }
		public DbSet<Proprietario> Proprietarios { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			{
				// Base abstrata
				modelBuilder.Entity<Imovel>()
					.HasKey(i => i.Id);

				modelBuilder.Entity<Imovel>()
					.Property(i => i.Matricula)
					.IsRequired();

				modelBuilder.Entity<Imovel>()
					.Property(i => i.Valor)
					.HasPrecision(18, 2)
					.IsRequired();

				// TPT - cada derivada em sua tabela
				modelBuilder.Entity<ImovelUrbano>()
					.ToTable("ImovelUrbano")
					.Property(u => u.Endereco)
					.IsRequired();

				modelBuilder.Entity<ImovelRural>()
					.ToTable("ImovelRural")
					.Property(r => r.Hectares)
					.HasPrecision(18, 2)
					.IsRequired();

				// Proprietário
				modelBuilder.Entity<Proprietario>()
					.HasKey(p => p.Id);

				modelBuilder.Entity<Proprietario>()
					.Property(p => p.Nome)
					.IsRequired();

				modelBuilder.Entity<Proprietario>()
					.ToTable("Proprietario");

				// Relacionamento N:N
				modelBuilder.Entity<Imovel>()
					.HasMany(i => i.Proprietarios) // agora usa o nome correto
					.WithMany()
					.UsingEntity(j => j.ToTable("ImovelProprietario"));
			}

		}
	}
}
