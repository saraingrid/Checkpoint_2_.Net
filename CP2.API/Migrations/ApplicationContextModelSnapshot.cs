﻿// <auto-generated />
using System;
using CP2.API.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CP2.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CP2.API.Domain.Entities.FornecedorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("CRIADOEM");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.ToTable("TB_FORNECEDOR");
                });

            modelBuilder.Entity("CP2.API.Domain.Entities.VendedorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ComissaoPercentual")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("COMISSAOPERCENTUAL");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("CRIADOEM");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATACONTRATACAO");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ENDERECO");

                    b.Property<decimal>("MetaMensal")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("METAMENSAL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.ToTable("TB_VENDEDOR");
                });
#pragma warning restore 612, 618
        }
    }
}