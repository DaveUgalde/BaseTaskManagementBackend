using MediatR;
using WorkModel.Application.Auth;

namespace WorkModel.Application.Auth.Commands;

public record RegisterCommand(
  string FirstName,
  string LastName,
  string UserName,
  string Email,
  string Password,
  string Role
) : IRequest<AuthResult>;