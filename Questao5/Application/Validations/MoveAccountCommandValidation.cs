using Questao5.Application.Commands.Requests;
using Questao5.Application.Validations.Validators;

namespace Questao5.Application.Validations
{
    public class MoveAccountCommandValidation : MoveAccountValidator//<MoveAccount>
    {
        public MoveAccountCommandValidation()
        {
            ValidateAccountId();
            ValidateValue();
            ValidateTypeMovement();
        }
    }
}
