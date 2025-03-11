using Questao5.Core.Messages;

namespace Questao5.Domain.Entities
{
    public class Idempotencia : Event
    {
        public Idempotencia(string id, string requisicao, string resultado)
        {
            Id = id;
            Requisicao = requisicao;
            Resultado = resultado;
        }

        protected Idempotencia() { }

        public string Id { get; private set; } = string.Empty;

        public string Requisicao { get; private set; } = string.Empty;

        public string Resultado { get; private set; } = string.Empty;
    }
}
