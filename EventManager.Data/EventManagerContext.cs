using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class EventManagerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=EventManager;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
