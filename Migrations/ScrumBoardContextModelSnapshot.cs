﻿// <auto-generated />
using BlazorScrumAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorScrumAPI.Migrations
{
    [DbContext(typeof(ScrumBoardContext))]
    partial class ScrumBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorScrumAPI.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "To Do"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<int>("BoardID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReporterID")
                        .HasColumnType("int");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeID");

                    b.HasIndex("BoardID");

                    b.HasIndex("ReporterID");

                    b.HasIndex("StateID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Username = "Alex Lackovic"
                        },
                        new
                        {
                            Id = 2,
                            Username = "Benjamin Roesdal"
                        });
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.Task", b =>
                {
                    b.HasOne("BlazorScrumAPI.Models.User", "Assignee")
                        .WithMany("AssigneeTasks")
                        .HasForeignKey("AssigneeID")
                        .IsRequired();

                    b.HasOne("BlazorScrumAPI.Models.Board", "Board")
                        .WithMany("Tasks")
                        .HasForeignKey("BoardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorScrumAPI.Models.User", "Reporter")
                        .WithMany("ReporterTasks")
                        .HasForeignKey("ReporterID")
                        .IsRequired();

                    b.HasOne("BlazorScrumAPI.Models.State", "State")
                        .WithMany("Tasks")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Board");

                    b.Navigation("Reporter");

                    b.Navigation("State");
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.Board", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.State", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BlazorScrumAPI.Models.User", b =>
                {
                    b.Navigation("AssigneeTasks");

                    b.Navigation("ReporterTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
