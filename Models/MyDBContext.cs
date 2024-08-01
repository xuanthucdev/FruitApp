using Microsoft.EntityFrameworkCore;
namespace ProjectDotNet.Models
{
    public partial class  MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)  :base(options){
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>(entity => {
             entity.HasKey(e =>  e.Id);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }



}
