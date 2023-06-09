﻿// <auto-generated />
using System;
using GuinchoSergipe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuinchoSergipe.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    [Migration("20230711103219_Recriando")]
    partial class Recriando
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GuinchoSergipe.Models.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.TipoVeiculoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TipoNome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposVeiculo");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.VeiculoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TipoVeiculoId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UserUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoVeiculoId");

                    b.HasIndex("UserId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.UserModel", b =>
                {
                    b.HasOne("GuinchoSergipe.Models.EnderecoModel", "Endereco")
                        .WithOne("User")
                        .HasForeignKey("GuinchoSergipe.Models.UserModel", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.VeiculoModel", b =>
                {
                    b.HasOne("GuinchoSergipe.Models.TipoVeiculoModel", "TipoVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("TipoVeiculoId");

                    b.HasOne("GuinchoSergipe.Models.UserModel", "User")
                        .WithMany("Veiculos")
                        .HasForeignKey("UserId");

                    b.Navigation("TipoVeiculo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.EnderecoModel", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("GuinchoSergipe.Models.TipoVeiculoModel", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GuinchoSergipe.Models.UserModel", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
