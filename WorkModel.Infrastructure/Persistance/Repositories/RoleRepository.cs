
using Microsoft.EntityFrameworkCore;
using WorkModel.Domain.Entities.Authentication;
using WorkModel.Domain.Interfaces.Repositories;
using WorkModel.Infrastructure.Persistance.Data;

namespace WorkModel.Infrastructure.Persistance.Repositories;

public class RoleRepository : IRoleRepository
{

  private readonly WorkModelDbContext _context;


  //Commands/ Modify states
  public RoleRepository(WorkModelDbContext context)
  {
    _context = context;
  }

  public async Task AddAsync(Role role)
  {
    await _context.Roles.AddAsync(role);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(Role role)
  {
    _context.Roles.Update(role);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(Role role)
  {
    _context.Roles.Remove(role);
    await _context.SaveChangesAsync();
  }

  //Read
  public async Task<IEnumerable<Role>> GetAllAsync()
  {
    return await _context.Roles.ToListAsync();
  }

  public async Task<Role?> GetByIdAsync(Guid id)
  {
    return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<Role?> GetByNameAsync(string roleName)
  {
    return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
  }
}