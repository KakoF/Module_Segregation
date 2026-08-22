using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace infrastructure.Data.Context
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

			// Aqui você pode usar uma string de conexão fake ou de dev
			optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MinhaAppDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
