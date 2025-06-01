using WorkModel.Domain.Entities.Authentication;
namespace WorkModel.Domain.Interfaces.Services;

public interface IJwtTokenGenerator
{
  string GenerateToken(User user, string roleName);
}
