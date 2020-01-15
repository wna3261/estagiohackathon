using Hackathon_API.Data.Mappings;
using Hackathon_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)  {}

        public DbSet<Candidato> Candidatos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatoMap());
        }
    }
}