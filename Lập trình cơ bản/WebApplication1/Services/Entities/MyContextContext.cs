using Microsoft.EntityFrameworkCore;
using Services.Entires;

namespace Services.Entities
{
    public class MyContextContext : DbContext
    {
        public MyContextContext() { }

        public MyContextContext(DbContextOptions<MyContextContext> options) : base(options)
        {
        }

        public virtual DbSet<Todo> totos { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Vehicle> vehicles { get; set; }

    }
}
