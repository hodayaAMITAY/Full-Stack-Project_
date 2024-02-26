using DAL.Domain;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        //internal object reposetories;
        //internal object registeries;
        //internal object registers;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Register> Registers { get; set; }

        public DbSet<Klip> Klips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2A40LMS\\SQLEXPRESS01;Database=newDB;TrustServerCertificate=True;Trusted_Connection=True");
        }

        /*protected override void OnConfiguring(ApplicationDbContext optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Example;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
