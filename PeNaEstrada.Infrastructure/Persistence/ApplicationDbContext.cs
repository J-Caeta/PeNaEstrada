using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Application.Interfaces;
using PeNaEstrada.Domain.Entities;
using PeNaEstrada.Infrastructure.Identity;
using System.Reflection;

namespace PeNaEstrada.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            builder.Entity<Experiencia>()
                .HasMany(e => e.GaleriaDeFotos)
                .WithOne(f => f.Experiencia)
                .HasForeignKey(f => f.ExperienciaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}