﻿// <auto-generated />
using System;
using LeaveManagementApplication.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeaveManagementApplication.Persistence.Migrations
{
    [DbContext(typeof(LeaveManagementDbContext))]
    partial class LeaveManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LeaveManagementApplication.Domain.Models.LeaveAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifyUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("leaveTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("numberOfDays")
                        .HasColumnType("integer");

                    b.Property<int>("period")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("leaveTypeId");

                    b.ToTable("LeaveAllocations");
                });

            modelBuilder.Entity("LeaveManagementApplication.Domain.Models.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifyUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<bool>("approved")
                        .HasColumnType("boolean");

                    b.Property<bool>("cancelled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("dateActioned")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dateRequested")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("leaveTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("requestComments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("leaveTypeId");

                    b.ToTable("LeaveRequest");
                });

            modelBuilder.Entity("LeaveManagementApplication.Domain.Models.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifyUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("defaultDay")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("LeaveType");
                });

            modelBuilder.Entity("LeaveManagementApplication.Domain.Models.LeaveAllocation", b =>
                {
                    b.HasOne("LeaveManagementApplication.Domain.Models.LeaveType", "leaveType")
                        .WithMany()
                        .HasForeignKey("leaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("leaveType");
                });

            modelBuilder.Entity("LeaveManagementApplication.Domain.Models.LeaveRequest", b =>
                {
                    b.HasOne("LeaveManagementApplication.Domain.Models.LeaveType", "leaveType")
                        .WithMany()
                        .HasForeignKey("leaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("leaveType");
                });
#pragma warning restore 612, 618
        }
    }
}
