using Microsoft.EntityFrameworkCore;

namespace GymProject1.Models
{
    public class GymContext : DbContext
    {
       public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AcademiaDb;Trusted_Connection=True;");
        }
    }
}
