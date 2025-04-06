using Microsoft.EntityFrameworkCore;
using Toplearn.DataLayer.Entities.User;

namespace Toplearn.DataLayer.Context;

public class ToplearnDbContext : DbContext
{
    public ToplearnDbContext(DbContextOptions<ToplearnDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
