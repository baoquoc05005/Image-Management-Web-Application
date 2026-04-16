using Microsoft.EntityFrameworkCore;
using ImageManagementApp.Models;

namespace ImageManagementApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ImageUploadMVC> ImageUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ImageUploadMVC>().ToTable("ImageUploads");
        }
    }
}
