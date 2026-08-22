using Domain.Models.Imovel.Enums;

namespace Domain.Models.Imovel
{
	public abstract class Imovel
	{
		public Guid Id { get; }
		public string Matricula { get; }
		public decimal Valor { get; }
		private List<Proprietario.Proprietario> _proprietarios = new();
		public IReadOnlyCollection<Proprietario.Proprietario> Proprietarios => _proprietarios.AsReadOnly();

		protected Imovel(Guid id, string matricula, decimal valor)
		{
			Id = id;
			Matricula = matricula;
			Valor = valor;
		}

		public abstract decimal CalcularIPTU();

		public void AdicionarProprietario(Proprietario.Proprietario proprietario)
		{
			var somaPorcentagem = _proprietarios.Sum(p => p.Porcentagem);

			if (somaPorcentagem + proprietario.Porcentagem > 100)
				throw new InvalidOperationException("A soma das porcentagens dos proprietários não pode ultrapassar 100.");

			_proprietarios.Add(proprietario);
			DefinirMajoritario();
		}

		private void DefinirMajoritario()
		{
			if (_proprietarios.Count == 0) return;

			var majoritario = _proprietarios.OrderByDescending(p => p.Porcentagem).First();
			majoritario.SetProprietarioComoMajoritario();
		}

		public static Imovel Create(TipoImovel tipo, Guid id, string matricula, decimal valor, string? endereco = null, decimal? hectares = null)
		{
			return tipo switch
			{
				TipoImovel.Urbano => new ImovelUrbano(
					id,
					matricula,
					valor,
					endereco ?? throw new ArgumentNullException(nameof(endereco))
				),

				TipoImovel.Rural => new ImovelRural(
					id,
					matricula,
					valor,
					hectares ?? throw new ArgumentNullException(nameof(hectares))
				),

				_ => throw new NotSupportedException(
					$"Tipo de imóvel não suportado: {tipo}")
			};
		}
	}
}
