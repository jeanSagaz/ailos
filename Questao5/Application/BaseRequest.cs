using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Questao5.Application
{
    public abstract class BaseRequest : IRequest<object?>
    {
        [JsonIgnore]
        public ValidationResult? ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
