using Microsoft.EntityFrameworkCore;
using WorkModel.Domain.Entities.Authentication;

namespace WorkModel.Infrastructure.Persistance.Data;

public class WorkModelDbContext : DbContext
{

  public WorkModelDbContext(DbContextOptions<WorkModelDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Role> Roles { get; set; }

  //Add more entities

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>()
    .HasOne(u => u.Role)
    .WithMany()
    .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<Role>().HasData(
        new Role { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Admin" },
        new Role { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "User" },
        new Role { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Guest" }
    );

  }

}