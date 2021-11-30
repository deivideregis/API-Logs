﻿// <auto-generated />
using System;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevIO.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20211130023702_Identity03")]
    partial class Identity03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevIO.Business.Models.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Detalhe")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoLogs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("DevIO.Business.Models.Maquina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MAC")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NomeMaquina")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("DevIO.Business.Models.TipoSistema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeSistema")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumeroSistema")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.ToTable("TipoSistema");
                });

            modelBuilder.Entity("DevIO.Business.Models.Log", b =>
                {
                    b.HasOne("DevIO.Business.Models.Maquina", "Maquina")
                        .WithMany("Logs")
                        .HasForeignKey("MaquinaId")
                        .IsRequired();
                });

            modelBuilder.Entity("DevIO.Business.Models.TipoSistema", b =>
                {
                    b.HasOne("DevIO.Business.Models.Maquina", "Maquina")
                        .WithMany("TipoSistema")
                        .HasForeignKey("MaquinaId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
