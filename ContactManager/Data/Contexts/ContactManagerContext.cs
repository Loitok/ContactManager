using ContactManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Contexts
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext() { }
        public ContactManagerContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContactManagerDB;Trusted_Connection=True;");
            }
        }

        public DbSet<CsvModel> CsvModels { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
    }
}
