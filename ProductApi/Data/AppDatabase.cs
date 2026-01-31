using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductAPI.Data
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options): base(options){}

        public DbSet<Product> Products => Set<Product>();
    }
}