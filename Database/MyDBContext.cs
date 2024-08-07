using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Models;
namespace ProjectDotNet.Database
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=fruit_app;User Id=sa;Password=yourpassword;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
                entity.Property(e => e.name).HasMaxLength(255).HasColumnName("name");
                entity.Property(e => e.email).HasMaxLength(255).HasColumnName("email");
                entity.Property(e => e.password).HasMaxLength(100).HasColumnName("password");
                entity.Property(e => e.address).HasMaxLength(255).HasColumnName("address");
                entity.Property(e => e.phone).HasMaxLength(255).HasColumnName("phone");


            }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }



}
