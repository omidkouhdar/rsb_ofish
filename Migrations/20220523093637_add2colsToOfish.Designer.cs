﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSB_Ofish_System.Data;

namespace RSB_Ofish_System.Migrations
{
    [DbContext(typeof(RSB_Ofish_SystemContext))]
    [Migration("20220523093637_add2colsToOfish")]
    partial class add2colsToOfish
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RSB_Ofish_System.Models.DataBaseModels.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Office");
                });

            modelBuilder.Entity("RSB_Ofish_System.Models.DataBaseModels.Ofish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OffishTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OnExitRegister")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Staff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Ofish");
                });

            modelBuilder.Entity("RSB_Ofish_System.Models.DataBaseModels.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sexual")
                        .HasColumnType("int");

                    b.Property<string>("sureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("RSB_Ofish_System.Models.DataBaseModels.Ofish", b =>
                {
                    b.HasOne("RSB_Ofish_System.Models.DataBaseModels.Office", "Office")
                        .WithMany("Ofishes")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RSB_Ofish_System.Models.DataBaseModels.Staff", b =>
                {
                    b.HasOne("RSB_Ofish_System.Models.DataBaseModels.Office", "Office")
                        .WithMany("Staffs")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
