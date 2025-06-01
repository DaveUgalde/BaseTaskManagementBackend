using MediatR;
using WorkModel.Application.Auth;
using WorkModel.Domain.Entities.Authentication;
using WorkModel.Domain.Interfaces.Repositories;
using WorkModel.Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace WorkModel.Application.Auth.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
{
  private readonly IUserRepository _userRepository;
  private readonly IRoleRepository _roleRepository;
  private IJwtTokenGenerator _jwtTokenGenerator;

  public RegisterCommandHandler(
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    IJwtTokenGenerator jwtRokenGenerator)
  {
    _userRepository = userRepository;
    _roleRepository = roleRepository;
    _jwtTokenGenerator = jwtRokenGenerator;
  }

  public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
  {
    var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
    if (existingUser is not null)
    {
      throw new Exception("User already exist.");
    }
    var hashedPassword = BC.HashPassword(request.Password);

    var role = await _roleRepository.GetByNameAsync("User")
    ?? throw new Exception("Default role not found");

    var user = new User
    {
      Id = Guid.NewGuid(),
      FirstName = request.FirstName,
      LastName = request.LastName,
      UserName = request.UserName,
      Email = request.Email,
      PasswordHash = hashedPassword,
      RoleId = role.Id,
      Role = role
    };
    await _userRepository.AddUser(user);

    var token = _jwtTokenGenerator.GenerateToken(user, user.Role.Name);

    return new AuthResult(
      user.Id,
      user.FirstName,
      user.LastName,
      user.UserName,
      user.Email,
      role.Name,
      token
    );
  }
}