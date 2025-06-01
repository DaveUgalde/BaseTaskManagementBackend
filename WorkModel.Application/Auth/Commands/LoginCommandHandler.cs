using MediatR;
using WorkModel.Domain.Entities.Authentication;
using WorkModel.Domain.Interfaces.Repositories;
using WorkModel.Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace WorkModel.Application.Auth.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult>
{
  private readonly IUserRepository _userRepository;
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public LoginCommandHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator
  )
  {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserByEmailAsync(request.Email);
    if (user is null || !BC.Verify(request.Password, user.PasswordHash))
    {
      throw new Exception("Invalid email or password.");
    }
    var token = _jwtTokenGenerator.GenerateToken(user, user.Role.Name ?? "Unknow");

    return new AuthResult(
     user.Id,
     user.FirstName,
     user.LastName,
     user.UserName,
     user.Email,
     user.Role?.Name ?? "Unknown",
     token
    );
  }
}