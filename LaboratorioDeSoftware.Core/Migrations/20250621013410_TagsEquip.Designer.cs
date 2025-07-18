﻿// <auto-generated />
using System;
using LaboratorioDeSoftware.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LaboratorioDeSoftware.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250621013410_TagsEquip")]
    partial class TagsEquip
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.CategoriaItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Equipamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CACalibracao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CAVerificacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CapacidadeMedicao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataColocacaoUso")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LaboratorioId")
                        .HasColumnType("uuid");

                    b.Property<long>("Num_Patrimonio")
                        .HasColumnType("bigint");

                    b.Property<long>("NumeroCertificadoCalibracao")
                        .HasColumnType("bigint");

                    b.Property<long>("Numero_Serie")
                        .HasColumnType("bigint");

                    b.Property<int>("PeriodicidadeCalibracao")
                        .HasColumnType("integer");

                    b.Property<int>("PeriodicidadeVerificacaoIntermediaria")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid");

                    b.Property<string>("ResolucaoDivisaoEscala")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorioId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Laboratorio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ResponsavelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Laboratorios");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MarcaFabricante")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoProduto")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.TagEquipamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EquipamentoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("TagsEquipamento");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Equipamento", b =>
                {
                    b.HasOne("LaboratorioDeSoftware.Core.Entities.Laboratorio", "Laboratorio")
                        .WithMany("Equipamentos")
                        .HasForeignKey("LaboratorioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LaboratorioDeSoftware.Core.Entities.Produto", "Produto")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Laboratorio");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Laboratorio", b =>
                {
                    b.HasOne("LaboratorioDeSoftware.Core.Entities.Usuario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.TagEquipamento", b =>
                {
                    b.HasOne("LaboratorioDeSoftware.Core.Entities.Equipamento", "Equipamento")
                        .WithMany("Tags")
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Equipamento", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Laboratorio", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("LaboratorioDeSoftware.Core.Entities.Produto", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
