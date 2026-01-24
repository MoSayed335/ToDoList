using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Person> Users { get; set; }
        public DbSet<Mission> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MARSNAN-UMMNUUB;Initial Catalog=ToDoList;Integrated Security=True;Connect Timeout=300;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

    }
}
