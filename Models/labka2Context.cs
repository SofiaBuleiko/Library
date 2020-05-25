using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class labka2Context : DbContext
    {
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<PublishingHouse> PublishingHouse { get; set; }
        public virtual DbSet<Reader> Reader { get; set; }
        public virtual DbSet<IssuingBooks> IssuingBooks { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<Authorships> Authorships { get; set; }

        public labka2Context(DbContextOptions<labka2Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
