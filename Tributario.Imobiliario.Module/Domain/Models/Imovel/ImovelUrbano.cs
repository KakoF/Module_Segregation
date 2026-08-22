
namespace Domain.Models.Imovel
{
	public sealed class ImovelUrbano : Imovel
	{
		public string Endereco { get; }

		// Construtor sem parâmetros para EF Core
		private ImovelUrbano() : base(Guid.Empty, string.Empty, 0) { }

		internal ImovelUrbano(Guid id, string matricula, decimal valor, string endereco) : base(id, matricula, valor)
		{
			Endereco = endereco;
		}

		public override decimal CalcularIPTU()
		{
			return Valor * 0.01m;
		}
	}
}
