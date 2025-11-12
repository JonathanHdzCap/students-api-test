
using Microsoft.EntityFrameworkCore;
using Usuarios.Api.Models;
namespace Usuarios.Api.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Email> Emails => Set<Email>();
        public DbSet<Phone> Phones => Set<Phone>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
