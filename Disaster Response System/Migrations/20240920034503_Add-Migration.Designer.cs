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
    [Migration("20240920034503_Add-Migration")]
    partial class AddMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Disaster_Response_System.Models.AffectedIndividual", b =>
                {
                    b.Property<Guid>("AffectedIndividualID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RequestID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AffectedIndividualID");

                    b.HasIndex("RequestID");

                    b.ToTable("AffectedIndividuals");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Donation", b =>
                {
                    b.Property<Guid>("DonationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("DonationAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonationPurpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DonorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("EstimatedValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DonationID");

                    b.HasIndex("DonorID");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Donor", b =>
                {
                    b.Property<Guid>("DonorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DonorID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.FinancialTransaction", b =>
                {
                    b.Property<Guid>("FinancialTransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DonorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FinancialTransactionID");

                    b.HasIndex("DonorID");

                    b.ToTable("FinancialTransactions");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.InventoryItem", b =>
                {
                    b.Property<Guid>("InventoryItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryItemID");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Request", b =>
                {
                    b.Property<Guid>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.RequestEvaluation", b =>
                {
                    b.Property<Guid>("RequestEvaluationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EvaluationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EvaluatorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ImpactScore")
                        .HasColumnType("int");

                    b.Property<int>("NeedScore")
                        .HasColumnType("int");

                    b.Property<Guid>("RequestID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ResourceAvailabilityScore")
                        .HasColumnType("int");

                    b.Property<int>("UrgencyScore")
                        .HasColumnType("int");

                    b.HasKey("RequestEvaluationID");

                    b.HasIndex("RequestID");

                    b.ToTable("RequestEvaluations");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.RequestItem", b =>
                {
                    b.Property<Guid>("RequestItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RequestID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestItemID");

                    b.HasIndex("RequestID");

                    b.ToTable("RequestItems");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.AffectedIndividual", b =>
                {
                    b.HasOne("Disaster_Response_System.Models.Request", "Request")
                        .WithMany("AffectedIndividuals")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Donation", b =>
                {
                    b.HasOne("Disaster_Response_System.Models.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.FinancialTransaction", b =>
                {
                    b.HasOne("Disaster_Response_System.Models.Donor", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.RequestEvaluation", b =>
                {
                    b.HasOne("Disaster_Response_System.Models.Request", "Request")
                        .WithMany("RequestEvaluations")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.RequestItem", b =>
                {
                    b.HasOne("Disaster_Response_System.Models.Request", "Request")
                        .WithMany("RequestItems")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Donor", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("Disaster_Response_System.Models.Request", b =>
                {
                    b.Navigation("AffectedIndividuals");

                    b.Navigation("RequestEvaluations");

                    b.Navigation("RequestItems");
                });
#pragma warning restore 612, 618
        }
    }
}
