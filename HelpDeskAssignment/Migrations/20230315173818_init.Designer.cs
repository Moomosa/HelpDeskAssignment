﻿// <auto-generated />
using System;
using HelpDeskAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelpDeskAssignment.Migrations
{
    [DbContext(typeof(HelpDeskAssignmentContext))]
    [Migration("20230315173818_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HelpDeskAssignment.Model.Tickets", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Escalated")
                        .HasColumnType("bit");

                    b.Property<string>("ResolutionComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Resolved")
                        .HasColumnType("bit");

                    b.Property<int?>("TicketResolverID")
                        .HasColumnType("int");

                    b.Property<int>("TicketSubmitterID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeResolved")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeSubmitted")
                        .HasColumnType("datetime2");

                    b.HasKey("TicketID");

                    b.HasIndex("TicketResolverID");

                    b.HasIndex("TicketSubmitterID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("HelpDeskAssignment.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HelpDeskAssignment.Model.Tickets", b =>
                {
                    b.HasOne("HelpDeskAssignment.Model.User", "TicketResolver")
                        .WithMany()
                        .HasForeignKey("TicketResolverID");

                    b.HasOne("HelpDeskAssignment.Model.User", "TicketSubmitter")
                        .WithMany("TicketList")
                        .HasForeignKey("TicketSubmitterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TicketResolver");

                    b.Navigation("TicketSubmitter");
                });

            modelBuilder.Entity("HelpDeskAssignment.Model.User", b =>
                {
                    b.Navigation("TicketList");
                });
#pragma warning restore 612, 618
        }
    }
}
