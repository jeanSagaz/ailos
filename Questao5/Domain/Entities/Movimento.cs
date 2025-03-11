using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public Movimento(string id, string idContaCorrente, DateTime dataMovimento, string tipoMovimento, decimal valor)
        {
            Id = id;
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }

        protected Movimento() { }

        public string Id { get; private set; } = string.Empty;

        public string IdContaCorrente { get; private set; } = string.Empty;

        public DateTime DataMovimento { get; private set; }

        public string TipoMovimento { get; private set; } = ETipoMovimento.Credito;

        public decimal Valor { get; private set; }

        public ContaCorrente? ContaCorrente { get; set; }
    }
}
