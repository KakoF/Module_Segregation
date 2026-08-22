using Domain.Models.Imovel.Enums;
using WebApplication2.Records.Proprietario;

namespace WebApplication2.Records.Imovel
{
	public record CreateImovelRequet(TipoImovel TipoImovel, string Matricula, Decimal Valor, IEnumerable<CreateProprietarioRequet> Proprietarios, string? Endereco, decimal? Hectares);
}
