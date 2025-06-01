using Microsoft.EntityFrameworkCore;
using WorkModel.Domain.Entities.Authentication;
using WorkModel.Domain.Interfaces.Repositories;
using WorkModel.Infrastructure.Persistance.Data;

namespace WorkModel.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{

  //CQRS
  //utiliza separacion de responsabilidades
  // Command= modifica el estado Create , Update, Delete
  //Query = GetById, GetAll, Search

  private readonly WorkModelDbContext _context;

  public UserRepository(WorkModelDbContext context)
  {
    _context = context;
  }

  // Commands/ Modify states
  public async Task AddUser(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
  }
  public async Task UpdateUserAsync(User user)
  {
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
  }
  public async Task DeleteAsync(User user)
  {
    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
  }
  // Read  
  public async Task<User?> GetUserById(Guid user)
  {
    return await _context.Users.Include(r => r.Role).FirstAsync(u => u.Id == user);
  }

  public async Task<User?> GetUserByNameAsync(string username)
  {
    return await _context.Users
      .Include(u => u.Role)
      .FirstAsync(u => u.UserName == username);
  }
    public async Task<User?> GetUserByEmailAsync(string email)
  {
    return await _context.Users
      .Include(u => u.Role)
      .FirstOrDefaultAsync(u => u.Email == email);
  }
  public async Task<IEnumerable<User>> GetAllUsers()
  {
    return await _context.Users.ToListAsync();
  }
}