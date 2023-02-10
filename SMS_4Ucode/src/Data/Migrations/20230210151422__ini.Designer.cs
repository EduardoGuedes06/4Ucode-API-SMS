﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _4Ucode_sms.Domain.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20230210151422__ini")]
    partial class _ini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.ContatoDocumento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.ToTable("tb_Contatos", (string)null);
                });

            modelBuilder.Entity("Domain.Models.EnvioDocumento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Enviado")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("NumeroId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TextoEnvio")
                        .IsRequired()
                        .HasColumnType("varchar(260)");

                    b.HasKey("Id");

                    b.HasIndex("NumeroId");

                    b.ToTable("tb_Envio", (string)null);
                });

            modelBuilder.Entity("Domain.Models.ModelTwillo.TwilloModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountSid")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FromPhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ServiceSid")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("StatusSend")
                        .HasColumnType("int");

                    b.Property<string>("ToPhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("twilloConfigs");
                });

            modelBuilder.Entity("Domain.Models.EnvioDocumento", b =>
                {
                    b.HasOne("Domain.Models.ContatoDocumento", "Numero")
                        .WithMany("EnvioDocumentos")
                        .HasForeignKey("NumeroId")
                        .IsRequired();

                    b.Navigation("Numero");
                });

            modelBuilder.Entity("Domain.Models.ContatoDocumento", b =>
                {
                    b.Navigation("EnvioDocumentos");
                });
#pragma warning restore 612, 618
        }
    }
}
