using Microsoft.EntityFrameworkCore;

namespace TestTaskApiPrototype2.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } // = null!;


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated(); //TODO: УБРАТЬ ИЗ КОНСТРУКТОРА
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=testDatabase.db");
        }
    }
}