﻿// <auto-generated />
using System;
using Alkemy.Disney.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alkemy.Disney.Api.Migrations
{
    [DbContext(typeof(MVCContext))]
    [Migration("20220529023039_DisneyMigration")]
    partial class DisneyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alkemy.Disney.Api.Domain.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Alkemy.Disney.Api.Domain.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Alkemy.Disney.Api.Domain.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.Property<string>("Title")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("TypeProduction")
                        .HasColumnType("int");

                    b.Property<int>("qualification")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Production");
                });

            modelBuilder.Entity("Alkemy.Disney.Api.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CharacterProduction", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionsId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "ProductionsId");

                    b.HasIndex("ProductionsId");

                    b.ToTable("CharacterProduction");
                });

            modelBuilder.Entity("GenderProduction", b =>
                {
                    b.Property<int>("GendersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionsId")
                        .HasColumnType("int");

                    b.HasKey("GendersId", "ProductionsId");

                    b.HasIndex("ProductionsId");

                    b.ToTable("GenderProduction");
                });

            modelBuilder.Entity("CharacterProduction", b =>
                {
                    b.HasOne("Alkemy.Disney.Api.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alkemy.Disney.Api.Domain.Production", null)
                        .WithMany()
                        .HasForeignKey("ProductionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenderProduction", b =>
                {
                    b.HasOne("Alkemy.Disney.Api.Domain.Gender", null)
                        .WithMany()
                        .HasForeignKey("GendersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alkemy.Disney.Api.Domain.Production", null)
                        .WithMany()
                        .HasForeignKey("ProductionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}