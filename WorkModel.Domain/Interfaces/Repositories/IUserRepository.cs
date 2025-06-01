using WorkModel.Domain.Entities.Authentication;
namespace WorkModel.Domain.Interfaces.Repositories;

public interface IUserRepository
{
  //getBy (Id, UserName, getAll)
  //Add User

  // Commands/ Modify states
  Task AddUser(User user);
  Task UpdateUserAsync(User user);
  Task DeleteAsync(User user);
  // Read  
  Task<User?> GetUserById(Guid Id);
  Task<User?> GetUserByEmailAsync(string email);
  Task<User?> GetUserByNameAsync(string username);
  Task<IEnumerable<User>> GetAllUsers();
}