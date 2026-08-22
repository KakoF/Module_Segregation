namespace Domain.Entities
{
	public class Produto
	{
		public Guid Id { get; private set; }
		public string Nome { get; private set; }

		public Produto(string nome)
		{
			Id = Guid.NewGuid();
			Nome = nome;
		}
	}
}
