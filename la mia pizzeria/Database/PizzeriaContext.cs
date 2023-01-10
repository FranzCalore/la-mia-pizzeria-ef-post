using la_mia_pizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria.Database
{
    public class PizzeriaContext:DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzeriaDB;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
