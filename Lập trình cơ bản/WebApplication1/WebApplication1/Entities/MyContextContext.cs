﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Entires;

namespace WebApplication1.Entities
{
    public class MyContextContext : DbContext
    {
        public MyContextContext() { }

        public MyContextContext(DbContextOptions<MyContextContext> options) : base(options)
        {
        }

        public virtual DbSet<Todo> totos { get; set; }
    }
}
