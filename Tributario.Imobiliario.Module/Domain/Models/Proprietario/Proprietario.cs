namespace Domain.Models.Proprietario
{
	public sealed class Proprietario
	{
		public Guid Id { get; private set; }
		public string Nome { get; private set; } = null!;
		public double Porcentagem { get; private set; }
		public bool Majoritario { get; private set; }

		private Proprietario(Guid id, string nome, double porcentagem)
		{
			Id = id;
			Nome = nome;
			Porcentagem = porcentagem;
		}

		public void SetProprietarioComoMajoritario()
		{
			Majoritario = true;
		}

		public static Proprietario Create(Guid id, string nome, double porcentagem)
		{
			if (porcentagem < 0 || porcentagem > 100)
			{
				throw new ArgumentOutOfRangeException(nameof(porcentagem), "A porcentagem deve estar entre 0 e 100.");
			}
			return new Proprietario(id, nome, porcentagem);
		}
	}
}
