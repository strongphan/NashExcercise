﻿// <auto-generated />
using System;
using ManhPT.EF_Core_Assignment_1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManhPT.EF_Core_Assignment_1.Model.Migrations
{
    [DbContext(typeof(BusinessContext))]
    [Migration("20240510092851_Inital")]
    partial class Inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("de1aa6b2-10ab-42cb-9507-942210f19974"),
                            Name = "Software Development"
                        },
                        new
                        {
                            Id = new Guid("f4c3a9be-476d-4937-85c6-1d618b9ef4fc"),
                            Name = "Finance"
                        },
                        new
                        {
                            Id = new Guid("541be00c-4922-4265-951f-c49c59370c7b"),
                            Name = "Accountant"
                        },
                        new
                        {
                            Id = new Guid("255ff132-ef6d-4577-ac58-ae9a8e89fb5a"),
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.ProjectEmployee", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProjectEmployees");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Employee", b =>
                {
                    b.HasOne("ManhPT.EF_Core_Assignment_1.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.ProjectEmployee", b =>
                {
                    b.HasOne("ManhPT.EF_Core_Assignment_1.Model.Employee", "Employee")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManhPT.EF_Core_Assignment_1.Model.Project", "Project")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Salary", b =>
                {
                    b.HasOne("ManhPT.EF_Core_Assignment_1.Model.Employee", "Employee")
                        .WithOne("Salary")
                        .HasForeignKey("ManhPT.EF_Core_Assignment_1.Model.Salary", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Employee", b =>
                {
                    b.Navigation("ProjectEmployees");

                    b.Navigation("Salary")
                        .IsRequired();
                });

            modelBuilder.Entity("ManhPT.EF_Core_Assignment_1.Model.Project", b =>
                {
                    b.Navigation("ProjectEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}