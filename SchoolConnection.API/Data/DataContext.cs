using Microsoft.EntityFrameworkCore;
using SchoolConnection.API.Models;

namespace SchoolConnection.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
    }
}