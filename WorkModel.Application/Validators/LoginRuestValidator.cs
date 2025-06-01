using FluentValidation;
using WorkModel.Application.DTO;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
  public RegisterRequestValidator()
  {
    RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.").MinimumLength(10).MaximumLength(50);
    RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.").MaximumLength(50);
    RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName name is required.").MinimumLength(4).MaximumLength(20);
    RuleFor(x => x.Email).NotEmpty().WithMessage("Valid email is required.").EmailAddress().WithMessage("Invalid email format");
    RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be at least 6 characters.").MinimumLength(6).WithMessage("Password must be at least 6 characters");
    RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required.").Must(role => new[] { "Admin", "User", "Client" }.Contains(role));
  }  
}