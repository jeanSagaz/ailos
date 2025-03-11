using FluentValidation;
using FluentValidation.Results;
using Questao5.Application.Commands.Requests;
using Questao5.Core.Resourcers;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Validations.Validators
{
    public class MoveAccountValidator : AbstractValidator<MoveAccountCommand>
    {
        protected void ValidateAccountId()
        {
            RuleFor(r => r.AccountId)
                .NotEmpty()
                .WithMessage(Errors.AccountIdNotEmpty)
                .OverridePropertyName("idConta");
        }

        protected void ValidateValue()
        {
            RuleFor(r => r.Value)
                .NotEmpty()
                .WithMessage(Errors.ValueNotEmpty)
                .GreaterThan(0)
                .WithMessage(Errors.ValueGreaterThan)
                .OverridePropertyName("valor");
        }

        public void TypeMovementCustom(string? typeMovement, ValidationContext<MoveAccountCommand> validationContext)
        {
            if (!string.IsNullOrEmpty(typeMovement))
            {
                if (typeMovement.ToUpper() != ETipoMovimento.Debito && 
                    typeMovement.ToUpper() != ETipoMovimento.Credito)
                {
                    validationContext.AddFailure(new ValidationFailure("INVALID_TYPE", Errors.TypeMovementCustom));
                }
            }
        }

        protected void ValidateTypeMovement()
        {
            RuleFor(r => r.TypeMovement)
                .NotEmpty()
                .WithMessage(Errors.TypeMovementNotEmpty)
                .OverridePropertyName("tipoMovimento")
                .Custom((e, context) =>
                {
                    TypeMovementCustom(e, context);
                });
        }
    }
}
