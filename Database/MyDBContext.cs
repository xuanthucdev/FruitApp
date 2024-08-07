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
        public virtual DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=;Database=fruit_app");
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
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("Name");
                entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("Description");
                entity.Property(e => e.Image).HasMaxLength(100).HasColumnName("imageURL");
                
                entity.Property(e => e.CategoryID).HasColumnType("int(2)").HasColumnName("CategoryID");
                entity.Property(e => e.Price).HasColumnType("int(6)").HasColumnName("Price");
            }
            );
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("categories");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("Name");
                


            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }



}
