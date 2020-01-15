using Hackathon_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon_API.Data.Mappings
{
    public class CandidatoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .IsRequired();

            builder.Property(x => x.Nota)
                .IsRequired();

            builder.Property(x => x.Situacao)
            .HasDefaultValue(false);
        }
    }
}