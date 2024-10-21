﻿// <auto-generated />
using System;
using Disaster_Response_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    [DbContext(typeof(DisasterResponseSystemDBContext))]
    [Migration("20241021023759_RequestFormAddition")]
    partial class RequestFormAddition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Disaster_Response_System.Models.Domain.Donor", b =>
                {
                    b.Property<Guid>("DonorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("Donation", b =>
                {
                    b.Property<Guid>("DonationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DonationAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DonorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoundID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DonationID");

                    b.HasIndex("DonorID");

                    b.HasIndex("RoundID");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Request", b =>
                {
                    b.Property<Guid>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AllocatedFunds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ApplicantContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EvaluationScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("RequestActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoundID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RequestID");

                    b.HasIndex("RoundID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Round", b =>
                {
                    b.Property<Guid>("RoundID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("RoundActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoundName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoundID");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Donation", b =>
                {
                    b.HasOne("Disaster_Response_System.Models.Domain.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Round", "Round")
                        .WithMany("Donations")
                        .HasForeignKey("RoundID");

                    b.Navigation("Donor");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Request", b =>
                {
                    b.HasOne("Round", "Round")
                        .WithMany("Requests")
                        .HasForeignKey("RoundID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Domain.Donor", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("Round", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
