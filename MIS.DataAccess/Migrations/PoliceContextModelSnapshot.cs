﻿// <auto-generated />
using System;
using MSI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MIS.DataAccess.Migrations
{
    [DbContext(typeof(PoliceContext))]
    partial class PoliceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("API.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("API.Model.CriminalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModifiedById");

                    b.ToTable("CriminalRecords");
                });

            modelBuilder.Entity("API.Model.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("API.Model.MeetingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RequesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ScheduledOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.ToTable("MeetingRequests");
                });

            modelBuilder.Entity("API.Model.PoliceSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("PoliceSections");
                });

            modelBuilder.Entity("API.Model.Policeman", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("CriminalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MeetingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MeetingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PoliceSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriminalRecordId");

                    b.HasIndex("MeetingId");

                    b.HasIndex("MeetingRequestId");

                    b.HasIndex("PoliceSectionId");

                    b.ToTable("Policemen");
                });

            modelBuilder.Entity("API.Model.PolicemanMeeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MeetingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PolicemanId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("PolicemanId");

                    b.ToTable("PolicemanMeetings");
                });

            modelBuilder.Entity("API.Model.CriminalRecord", b =>
                {
                    b.HasOne("API.Model.Policeman", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("API.Model.MeetingRequest", b =>
                {
                    b.HasOne("API.Model.Policeman", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("API.Model.PoliceSection", b =>
                {
                    b.HasOne("API.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("API.Model.Policeman", b =>
                {
                    b.HasOne("API.Model.CriminalRecord", null)
                        .WithMany("Policemen")
                        .HasForeignKey("CriminalRecordId");

                    b.HasOne("API.Model.Meeting", null)
                        .WithMany("Policemen")
                        .HasForeignKey("MeetingId");

                    b.HasOne("API.Model.MeetingRequest", null)
                        .WithMany("Policemen")
                        .HasForeignKey("MeetingRequestId");

                    b.HasOne("API.Model.PoliceSection", null)
                        .WithMany("Policemen")
                        .HasForeignKey("PoliceSectionId");
                });

            modelBuilder.Entity("API.Model.PolicemanMeeting", b =>
                {
                    b.HasOne("API.Model.Meeting", "Meeting")
                        .WithMany()
                        .HasForeignKey("MeetingId");

                    b.HasOne("API.Model.Policeman", "Policeman")
                        .WithMany()
                        .HasForeignKey("PolicemanId");

                    b.Navigation("Meeting");

                    b.Navigation("Policeman");
                });

            modelBuilder.Entity("API.Model.CriminalRecord", b =>
                {
                    b.Navigation("Policemen");
                });

            modelBuilder.Entity("API.Model.Meeting", b =>
                {
                    b.Navigation("Policemen");
                });

            modelBuilder.Entity("API.Model.MeetingRequest", b =>
                {
                    b.Navigation("Policemen");
                });

            modelBuilder.Entity("API.Model.PoliceSection", b =>
                {
                    b.Navigation("Policemen");
                });
#pragma warning restore 612, 618
        }
    }
}
