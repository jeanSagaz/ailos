using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public ContaCorrente(string id, int numero, string nome, EAtivo ativo)
        {
            Id = id;
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
        }

        protected ContaCorrente() { }

        public string Id { get; private set; } = string.Empty;

        public int Numero { get; private set; }

        public string Nome { get; private set; } = string.Empty;

        public EAtivo Ativo { get; private set; } = EAtivo.Ativo;

        public ICollection<Movimento> Movimentos { get; set; } = new List<Movimento>();
    }
}
