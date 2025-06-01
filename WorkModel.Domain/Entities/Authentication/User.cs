using BCrypt.Net;
namespace WorkModel.Domain.Entities.Authentication;

public class User : EntityBase
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string UserName { get; set; }
  public string Email { get; set; }
  public string PasswordHash { get; set; }

  //Relation with Rol
  public Guid RoleId { get; set; }
  public Role Role { get; set; }

  //Constructor for EF Core
  public User() { }

  public User(string firstName, string lastName,string userName, string email, string rawPassword, Role role)
  {
    FirstName = firstName;
    LastName = lastName;
    UserName = userName;
    Email = email;
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(rawPassword);
    Role = role;
    RoleId = role.Id;
  }

  public bool VerifyPassword(string rawPassword)
  {
    return BCrypt.Net.BCrypt.Verify(rawPassword, PasswordHash);
  }

  public void ChangePassword(string newRwPassword)
  {
    PasswordHash = BCrypt.Net.BCrypt.HashPassword(newRwPassword);
  }

}