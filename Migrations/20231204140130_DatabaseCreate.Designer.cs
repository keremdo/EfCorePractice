﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efcoreApp.Data;

#nullable disable

namespace efcoreApp.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20231204140130_DatabaseCreate")]
    partial class DatabaseCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("efcoreApp.Data.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .HasColumnType("longtext");

                    b.Property<string>("CourseTitle")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("efcoreApp.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentName")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentSurName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
