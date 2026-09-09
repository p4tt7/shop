using Microsoft.EntityFrameworkCore;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Password).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Username).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Role).HasConversion<string>();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e=>e.Name).IsRequired().HasMaxLength(50); 
        }
        );
    }
}