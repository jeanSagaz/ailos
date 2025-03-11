using Questao5.Application.Commands.Requests;
using Questao5.Core.Resourcers;
using Xunit;

namespace Questao5.Tests.Unit_Tests
{
    public class AccountControllerTests
    {
        private readonly MoveAccountCommand _moveAccountCommand;

        public AccountControllerTests()
        {
            _moveAccountCommand = new MoveAccountCommand();
        }

        [Fact(DisplayName = "Registrar movimentação da conta com idConta nulo")]
        [Trait("Category", "Testes Account Controller")]
        public void AccountController_RegisterAccount_AccountIdNull()
        {
            // Arrange

            // Act
            var isValid = _moveAccountCommand.IsValid();
            var error = _moveAccountCommand.ValidationResult?.Errors.FirstOrDefault(e => e.ErrorMessage.Equals(Errors.AccountIdNotEmpty));

            // Assert
            Assert.False(isValid);
            Assert.NotNull(error);
        }

        [Fact(DisplayName = "Registrar movimentação da conta com erro valor nulo")]
        [Trait("Category", "Testes Account Controller")]
        public void AccountController_RegisterAccount_ValueNull()
        {
            // Arrange

            // Act
            var isValid = _moveAccountCommand.IsValid();
            var error = _moveAccountCommand.ValidationResult?.Errors.FirstOrDefault(e => e.ErrorMessage.Equals(Errors.ValueNotEmpty));

            // Assert
            Assert.False(isValid);
            Assert.NotNull(error);
        }

        [Fact(DisplayName = "Registrar movimentação da conta com erro valor negativo")]
        [Trait("Category", "Testes Account Controller")]
        public void AccountController_RegisterAccount_NegativeValue()
        {
            // Arrange
            _moveAccountCommand.Value = -5;

            // Act
            var isValid = _moveAccountCommand.IsValid();
            var error = _moveAccountCommand.ValidationResult?.Errors.FirstOrDefault(e => e.ErrorMessage.Equals(Errors.ValueGreaterThan));

            // Assert
            Assert.False(isValid);
            Assert.NotNull(error);
        }

        [Fact(DisplayName = "Registrar movimentação da conta com erro tipo de movimento inválido")]
        [Trait("Category", "Testes Account Controller")]
        public void AccountController_RegisterAccount_InvalidTypeMovement()
        {
            // Arrange
            _moveAccountCommand.TypeMovement = "a";

            // Act
            var isValid = _moveAccountCommand.IsValid();
            var error = _moveAccountCommand.ValidationResult?.Errors.FirstOrDefault(e => e.ErrorMessage.Equals(Errors.TypeMovementCustom));

            // Assert
            Assert.False(isValid);
            Assert.NotNull(error);
        }
    }
}
