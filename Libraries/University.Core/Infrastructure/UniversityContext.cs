using System;
using Microsoft.EntityFrameworkCore;
using University.Core.Domain;

namespace University.Core.Infrastructure
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
