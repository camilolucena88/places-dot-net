using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}