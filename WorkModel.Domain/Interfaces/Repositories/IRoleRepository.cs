using WorkModel.Domain.Entities.Authentication;
namespace WorkModel.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
  //getBy (Id, Name, getAll)
  //Add User
  Task<Role?> GetByIdAsync(Guid id);
  Task<Role?> GetByNameAsync(string roleName);
  Task<IEnumerable<Role>> GetAllAsync();
  Task AddAsync(Role role);
}
