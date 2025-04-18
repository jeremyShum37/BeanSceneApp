﻿// <auto-generated />
using System;
using BeanSceneApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeanSceneApp.Migrations
{
    [DbContext(typeof(BeanSceneAppContext))]
    partial class BeanSceneAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeanSceneApp.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaId"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("GuestCount")
                        .HasColumnType("int");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("SittingId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("MemberId");

                    b.HasIndex("SittingId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Sitting", b =>
                {
                    b.Property<int>("SittingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SittingId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("SittingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SittingId");

                    b.ToTable("Sittings");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("TableNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("TableId", "ReservationId");

                    b.HasIndex("AreaId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("BeanSceneApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Type")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("User_Type").HasValue("User_Base");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BeanSceneApp.Models.Member", b =>
                {
                    b.HasBaseType("BeanSceneApp.Models.User");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("User_Memb");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Reservation", b =>
                {
                    b.HasOne("BeanSceneApp.Models.Member", "Member")
                        .WithMany("Reservation")
                        .HasForeignKey("MemberId");

                    b.HasOne("BeanSceneApp.Models.Sitting", "Sitting")
                        .WithMany("Reservation")
                        .HasForeignKey("SittingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Sitting");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Table", b =>
                {
                    b.HasOne("BeanSceneApp.Models.Area", "Area")
                        .WithMany("Table")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneApp.Models.Reservation", "Reservation")
                        .WithMany("Table")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Area", b =>
                {
                    b.Navigation("Table");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Reservation", b =>
                {
                    b.Navigation("Table");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Sitting", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("BeanSceneApp.Models.Member", b =>
                {
                    b.Navigation("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
