using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoeAirlines.Entities;
using VoeAirlines.EntityConfigurations;




/*

namespace VoeAirlines.EntityConfigurations;

public class AeronaveConfiguration : IEntityTypeConfiguration<Aeronave>
{
    public void Configure(EntityTypeBuilder<Aeronave> builder)
    {
        //tabela
       builder.ToTable("Aeronaves");
       //chave primária
       builder.HasKey(a=>a.Id) ;

       //outras propriedades:
       builder.Property(a=> a.Fabricante)
           .IsRequired()
           .HasMaxLength(50);
       builder.Property(a=> a.Modelo)
           .IsRequired()
           .HasMaxLength(50);
       builder.Property(a=> a.Codigo)
           .IsRequired()
           .HasMaxLength(10);

           //chave estrangeira 
           builder.HasMany(a=>a.Manutencoes)
                 .WithOne(m=>m.Aeronave)
                 .HasForeignKey(m=>m.AeronaveId);
           
    }
}*/