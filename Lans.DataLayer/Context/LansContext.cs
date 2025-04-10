using Microsoft.EntityFrameworkCore;
using Lans.DataLayer.Entities.User;

namespace Lans.DataLayer.Context;

public class LansDbContext : DbContext
{
    public LansDbContext(DbContextOptions<LansDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
