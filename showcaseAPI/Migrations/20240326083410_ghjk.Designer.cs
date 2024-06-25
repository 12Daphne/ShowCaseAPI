﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using showcaseAPI.Data;

#nullable disable

namespace showcaseAPI.Migrations
{
    [DbContext(typeof(DbController))]
    [Migration("20240326083410_ghjk")]
    partial class ghjk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("showcaseAPI.Models.Rooms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomPassword")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("showcaseAPI.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("LastVerify")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Verify")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("showcaseAPI.Models.Users", b =>
                {
                    b.HasOne("showcaseAPI.Models.Rooms", "Room")
                        .WithMany("Players")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("showcaseAPI.Models.Rooms", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
