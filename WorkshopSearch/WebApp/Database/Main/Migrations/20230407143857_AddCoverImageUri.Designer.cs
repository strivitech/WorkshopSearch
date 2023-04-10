﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.Database.Main;

#nullable disable

namespace WebApp.Database.Main.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230407143857_AddCoverImageUri")]
    partial class AddCoverImageUri
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DirectionWorkshop", b =>
                {
                    b.Property<int>("DirectionsId")
                        .HasColumnType("integer");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.HasKey("DirectionsId", "WorkshopId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("DirectionWorkshop");
                });

            modelBuilder.Entity("WebApp.Features.Directions.Direction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("WebApp.Features.Workshops.Workshop", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CoverImageUri")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)");

                    b.Property<string>("ImageUris")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("DirectionWorkshop", b =>
                {
                    b.HasOne("WebApp.Features.Directions.Direction", null)
                        .WithMany()
                        .HasForeignKey("DirectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Features.Workshops.Workshop", null)
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Features.Workshops.Workshop", b =>
                {
                    b.OwnsOne("WebApp.Features.Workshops.ContactInfo", "ContactInformation", b1 =>
                        {
                            b1.Property<Guid>("WorkshopId")
                                .HasColumnType("uuid");

                            b1.Property<string>("ContactLinks")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)");

                            b1.HasKey("WorkshopId");

                            b1.ToTable("Workshops");

                            b1.WithOwner()
                                .HasForeignKey("WorkshopId");
                        });

                    b.OwnsOne("WebApp.Features.Workshops.WorkshopConstrains", "Constrains", b1 =>
                        {
                            b1.Property<Guid>("WorkshopId")
                                .HasColumnType("uuid");

                            b1.Property<byte>("Days")
                                .HasColumnType("smallint");

                            b1.Property<int>("MaxAge")
                                .HasColumnType("integer");

                            b1.Property<int>("MinAge")
                                .HasColumnType("integer");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric");

                            b1.HasKey("WorkshopId");

                            b1.ToTable("Workshops");

                            b1.WithOwner()
                                .HasForeignKey("WorkshopId");
                        });

                    b.Navigation("Constrains")
                        .IsRequired();

                    b.Navigation("ContactInformation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
