namespace WorkModel.Application.Auth;


//record immutabilidad, se puede definir como elementos de solo lectura que no se modifican
public record AuthResult(
  Guid UserId,
  string FirstName,
  string LastName,
  string UserName,
  string Email,
  string Role,
  string Token = "Default"
);