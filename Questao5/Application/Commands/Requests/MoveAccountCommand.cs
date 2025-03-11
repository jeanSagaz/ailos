using Questao5.Application.Validations;
using System.Text.Json.Serialization;

namespace Questao5.Application.Commands.Requests
{
    public class MoveAccountCommand : BaseRequest
    {
        [JsonPropertyName("idConta")]
        public string? AccountId { get; set; }

        [JsonPropertyName("valor")]
        public decimal? Value { get; set; }

        [JsonPropertyName("tipoMovimento")]
        public string? TypeMovement { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new MoveAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
