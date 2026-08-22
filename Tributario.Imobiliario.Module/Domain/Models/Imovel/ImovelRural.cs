namespace Domain.Models.Imovel
{
	public sealed class ImovelRural : Imovel
	{
		public decimal Hectares { get; }

		// Construtor sem parâmetros para EF Core
		private ImovelRural() : base(Guid.Empty, string.Empty, 0) { }

		internal ImovelRural(Guid id, string matricula, decimal valor, decimal hectares) : base(id, matricula, valor)
		{
			Hectares = hectares;
		}

		public override decimal CalcularIPTU()
		{
			return Valor * 0.005m;
		}
	}
}
