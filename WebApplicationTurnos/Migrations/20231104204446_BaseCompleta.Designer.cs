﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationTurnos.Models;

#nullable disable

namespace WebApplicationTurnos.Migrations
{
    [DbContext(typeof(TurnosContext))]
    [Migration("20231104204446_BaseCompleta")]
    partial class BaseCompleta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationTurnos.Models.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Especialidad");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Cariólogo"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Odontólogo"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Traumatólogo"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Oftalmólogo"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Pediatra"
                        });
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Login");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "BBAF85A574B5B26907872548398B034EDB8DD7D794CE74D4E4461EBFA6224581",
                            Usuario = "mariano"
                        });
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<TimeSpan>("HorarioAtencionDesde")
                        .IsUnicode(false)
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioAtencionHasta")
                        .IsUnicode(false)
                        .HasColumnType("time");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Medico");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Lascares",
                            Direccion = "San Juan 1349",
                            Email = "mariano.lascares@gmail.com",
                            HorarioAtencionDesde = new TimeSpan(0, 7, 0, 0, 0),
                            HorarioAtencionHasta = new TimeSpan(0, 15, 0, 0, 0),
                            Nombre = "Mariano",
                            Telefono = "3416676363"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Mansilla",
                            Direccion = "San Juan 1349",
                            Email = "ornela.mansilla@gmail.com",
                            HorarioAtencionDesde = new TimeSpan(0, 9, 0, 0, 0),
                            HorarioAtencionHasta = new TimeSpan(0, 16, 0, 0, 0),
                            Nombre = "Ornela",
                            Telefono = "3416423125"
                        });
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.MedicoEspecialidad", b =>
                {
                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.HasKey("IdMedico", "IdEspecialidad");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("MedicoEspecialidad");

                    b.HasData(
                        new
                        {
                            IdMedico = 1,
                            IdEspecialidad = 1
                        },
                        new
                        {
                            IdMedico = 2,
                            IdEspecialidad = 5
                        });
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Pacientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Lascares",
                            Direccion = "San Juan 1349",
                            Email = "emma.lascares@gmail.com",
                            Nombre = "Emma",
                            Telefono = "3416741852"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Lascares",
                            Direccion = "San Juan 1349",
                            Email = "ian.lascares@gmail.com",
                            Nombre = "Ian",
                            Telefono = "3416444235"
                        });
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaHoraFin")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHoraInicio")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMedico")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.MedicoEspecialidad", b =>
                {
                    b.HasOne("WebApplicationTurnos.Models.Especialidad", "EspecialidadNavigation")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationTurnos.Models.Medico", "MedicoNavigation")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EspecialidadNavigation");

                    b.Navigation("MedicoNavigation");
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Turno", b =>
                {
                    b.HasOne("WebApplicationTurnos.Models.Medico", "MedicoNavigation")
                        .WithMany("Turnos")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationTurnos.Models.Pacientes", "PacientesNavigation")
                        .WithMany("Turnos")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicoNavigation");

                    b.Navigation("PacientesNavigation");
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Especialidad", b =>
                {
                    b.Navigation("MedicoEspecialidad");
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Medico", b =>
                {
                    b.Navigation("MedicoEspecialidad");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("WebApplicationTurnos.Models.Pacientes", b =>
                {
                    b.Navigation("Turnos");
                });
#pragma warning restore 612, 618
        }
    }
}
