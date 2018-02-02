﻿// <auto-generated />
using ListenThen.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ListenThen.Infra.Data.Migrations
{
    [DbContext(typeof(ListenThenContext))]
    [Migration("20180117171016_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ListenThen.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Genre");

                    b.Property<Guid?>("JobTitleId");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ListenThen.Domain.Models.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("JobTitle");
                });

            modelBuilder.Entity("ListenThen.Domain.Models.MeetingNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<Guid?>("OneToOneMeetingId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("OneToOneMeetingId");

                    b.ToTable("MeetingNote");
                });

            modelBuilder.Entity("ListenThen.Domain.Models.MeetingPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<Guid?>("OneToOneMeetingId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("OneToOneMeetingId");

                    b.ToTable("MeetingPoint");
                });

            modelBuilder.Entity("ListenThen.Domain.Models.OneToOneMeeeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created");

                    b.Property<Guid?>("ManagerId");

                    b.Property<Guid?>("ReceiverId");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("OneToOneMeeeting");
                });

            modelBuilder.Entity("ListenThen.Domain.Models.Employee", b =>
                {
                    b.HasOne("ListenThen.Domain.Models.JobTitle", "JobTitle")
                        .WithMany("Employees")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ListenThen.Domain.Models.MeetingNote", b =>
                {
                    b.HasOne("ListenThen.Domain.Models.Employee", "Author")
                        .WithMany("MeetingNoteAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ListenThen.Domain.Models.OneToOneMeeeting", "OneToOneMeeting")
                        .WithMany("Notes")
                        .HasForeignKey("OneToOneMeetingId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ListenThen.Domain.Models.MeetingPoint", b =>
                {
                    b.HasOne("ListenThen.Domain.Models.Employee", "Author")
                        .WithMany("MeetingPointAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ListenThen.Domain.Models.OneToOneMeeeting", "OneToOneMeeting")
                        .WithMany("Points")
                        .HasForeignKey("OneToOneMeetingId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ListenThen.Domain.Models.OneToOneMeeeting", b =>
                {
                    b.HasOne("ListenThen.Domain.Models.Employee", "Manager")
                        .WithMany("OneToOneMeetingManagers")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ListenThen.Domain.Models.Employee", "Receiver")
                        .WithMany("OneToOneMeetingReceivers")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
