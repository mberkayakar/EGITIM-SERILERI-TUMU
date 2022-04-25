using AKAR.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AKAR.WebAPI.Data
{
    public class MyDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AKAR_WEB_API;Integrated Security=true");
        }

        public DbSet<Product> Products { get; set; }
    }
}
