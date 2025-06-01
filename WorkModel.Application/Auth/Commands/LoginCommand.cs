using MediatR;
using WorkModel.Application.Auth;

namespace WorkModel.Application.Auth.Commands;

public record LoginCommand(
  string Email,
  string Password
) : IRequest<AuthResult>;