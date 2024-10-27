namespace radlab5._1.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
