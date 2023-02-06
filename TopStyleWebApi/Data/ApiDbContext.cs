using Microsoft.EntityFrameworkCore;
using TopStyleWebApi.Models;

namespace TopStyleWebApi.Data;

public class ApiDbContext:DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    { }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<User> Users { get; set; }
    
}