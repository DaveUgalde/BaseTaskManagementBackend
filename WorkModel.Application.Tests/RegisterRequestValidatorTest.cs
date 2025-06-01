using Xunit;
using FluentValidation.TestHelper;
using WorkModel.Application.Services;
using WorkModel.Application.DTO;

namespace WorkModel.Application.Tests;

public class RegisterRequestValidatorTest
{
    private readonly RegisterRequestValidator _validator = new RegisterRequestValidator();
    //Fact prueba unitaria simple que no recibe parametros.
    //Sirve para probar un solo caso en especifico.

    //Theory = indica que una prueba va a ser testeada varias veces con diferentes datos de entrada.


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    public void Should_Have_Error_When_FirstName_Is_Invalid(string firstName)
    {
        var model = new RegisterRequest(firstName, "Smith", "Doe", "john@example.com", "password123", "Admin");
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);

    }

}