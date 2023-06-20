using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Asp_Labb1.Models;

namespace Asp_Labb1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Asp_Labb1.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Asp_Labb1.Models.Absence> Absence { get; set; } = default!;
        public DbSet<Asp_Labb1.Models.AbsenceType> AbsenceType { get; set; } = default!;
    }
}