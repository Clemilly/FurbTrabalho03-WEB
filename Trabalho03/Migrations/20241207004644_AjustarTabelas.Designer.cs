﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trabalho03.Data;

#nullable disable

namespace Trabalho03.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241207004644_AjustarTabelas")]
    partial class AjustarTabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.Property<Guid>("AlunosId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TurmasId")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunosId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nome");

                    b.Property<Guid?>("TurmaId")
                        .HasColumnType("TEXT")
                        .HasColumnName("TurmaId");

                    b.HasKey("Id");

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Materia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("TEXT")
                        .HasColumnName("AlunoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Materia", (string)null);
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Nota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("TEXT")
                        .HasColumnName("AlunoId");

                    b.Property<Guid>("MateriaId")
                        .HasColumnType("TEXT")
                        .HasColumnName("MateriaId");

                    b.Property<int>("Peso")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Peso");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Nota", (string)null);
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Turma", (string)null);
                });

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.HasOne("Trabalho03.Models.Entities.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trabalho03.Models.Entities.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Materia", b =>
                {
                    b.HasOne("Trabalho03.Models.Entities.Aluno", "Aluno")
                        .WithMany("Materias")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Nota", b =>
                {
                    b.HasOne("Trabalho03.Models.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trabalho03.Models.Entities.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Trabalho03.Models.Entities.Aluno", b =>
                {
                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
