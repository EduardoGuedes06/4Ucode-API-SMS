﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class DadosClienteMapping : IEntityTypeConfiguration<DadosCliente>
    {
        public void Configure(EntityTypeBuilder<DadosCliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeCliente)
               .IsRequired()
               .HasColumnType("varchar(75)");

                //1 : N => Cliente : Conteudo
            builder.HasMany(f => f.ConteudoCliente)
                .WithOne(p => p.DadosCliente)
                .HasForeignKey(p => p.ClienteId);

                //1 : N => Cliente : Envio
            builder.HasMany(f => f.EnvioDocumentos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);

            //1 : N => Cliente : Contatos
            builder.HasMany(f => f.ContatoDocumento)
                .WithOne(p => p.DadosCliente)
                .HasForeignKey(p => p.ClienteId);

            //1 : 1 => Cliente: Usuario
            //builder.HasOne(m => m.ApplicationUser)
            //.WithMany()
            //.HasForeignKey(m => m.UserId);


            builder.ToTable("tb_cliente");
        }
    }
}