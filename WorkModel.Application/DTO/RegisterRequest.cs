namespace WorkModel.Application.DTO;

public record RegisterRequest(
  string FirstName,
  string LastName,
  string UserName,
  string Email,
  string Password,
  string Role
);