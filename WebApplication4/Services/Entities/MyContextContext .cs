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

		public virtual DbSet<Giaovien> giaoviens { get; set; }
		public virtual DbSet<Hocsinh> hocsinhs { get; set; }
		public virtual DbSet<Lop> lops { get; set; }
	}
}