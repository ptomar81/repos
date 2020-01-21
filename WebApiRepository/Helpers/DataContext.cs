using Microsoft.EntityFrameworkCore;
using WebApiRepository.Models;

namespace WebApiRepository.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}