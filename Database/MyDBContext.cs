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
        
        public virtual DbSet<Account> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=;Database=fruit_app");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("FullName");
                entity.Property(e => e.Email).HasMaxLength(255).HasColumnName("Email");
                entity.Property(e => e.Password).HasMaxLength(100).HasColumnName("Password");
                entity.Property(e => e.Address).HasMaxLength(255).HasColumnName("Address");
                entity.Property(e => e.Phone).HasMaxLength(255).HasColumnName("PhoneNumber");
                entity.Property(e => e.Role).HasColumnType("int(1)").HasColumnName("role");

            }
            );
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("Name");
                entity.Property(e => e.Description).HasMaxLength(100).HasColumnName("Description");
                entity.Property(e => e.Image).HasMaxLength(100).HasColumnName("imageURL");
                entity.Property(e => e.CategoryID).HasColumnType("int(2)").HasColumnName("CategoryID");
                entity.Property(e => e.Price).HasColumnType("int(11)").HasColumnName("Price");
                entity.Property(e => e.Stock).HasColumnType("int(11)").HasColumnName("Stock");
            }
            );
            
         
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("categories");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("Name");

                entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("Description");

            });
            modelBuilder.Entity<DescriptionDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("descriptiondetails");
                entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
                entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
                entity.Property(e => e.weight).HasColumnType("int(11)").HasColumnName("weight");
                entity.Property(e => e.country).HasMaxLength(255).HasColumnName("country");
                entity.Property(e => e.maxWeight).HasColumnType("int(11)").HasColumnName("maxWeight");
                entity.Property(e => e.quality).HasMaxLength(255).HasColumnName("quality");
                entity.Property(e => e.status).HasMaxLength(255).HasColumnName("status");



            });
            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PRIMARY");
                entity.ToTable("orderdetails");

                entity.Property(e => e.ID)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.OrderID)
                    .HasColumnType("int(11)")
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductID)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("Quantity");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("UnitPrice");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("Total");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("FirstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("LastName");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("Address");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("Phone");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("Email");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("Note");
                entity.Property(e => e.status)
                  .HasColumnType("int(11)")
                  .HasColumnName("status");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }



}
