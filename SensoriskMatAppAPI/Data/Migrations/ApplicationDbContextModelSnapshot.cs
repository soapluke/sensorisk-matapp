﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Chapter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Entities.FreetextAnswer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("FreetextQuestionID");

                    b.HasKey("ID");

                    b.HasIndex("FreetextQuestionID");

                    b.ToTable("FreetextAnswer");
                });

            modelBuilder.Entity("Entities.FreetextQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Question");

                    b.HasKey("ID");

                    b.ToTable("FreetextQuestion");
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("OneOption");

                    b.Property<bool>("OwnOption");

                    b.Property<string>("Question");

                    b.HasKey("ID");

                    b.ToTable("MultichoiceQuestion");
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion_Options", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MultichoiceQuestionID");

                    b.Property<int>("OptionsID");

                    b.HasKey("ID");

                    b.HasIndex("MultichoiceQuestionID");

                    b.HasIndex("OptionsID");

                    b.ToTable("MultichoiceQuestion_Options");
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion_OptionsAnswer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MultichoiceQuestionID");

                    b.Property<int>("OptionsID");

                    b.HasKey("ID");

                    b.HasIndex("MultichoiceQuestionID");

                    b.HasIndex("OptionsID");

                    b.ToTable("MultichoiceQuestion_OptionsAnswer");
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion_UsersOptions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MultichoiceQuestionID");

                    b.Property<int>("UsersOptionsID");

                    b.HasKey("ID");

                    b.HasIndex("MultichoiceQuestionID");

                    b.HasIndex("UsersOptionsID");

                    b.ToTable("MultichoiceQuestion_UsersOptions");
                });

            modelBuilder.Entity("Entities.Options", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Option");

                    b.HasKey("ID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Entities.Organisation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Friendly");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<byte[]>("Picture");

                    b.HasKey("ID");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("Entities.Survey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Code");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("OrganisationID");

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("OrganisationID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Entities.Survey_FreetextQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChapterID");

                    b.Property<int>("FreetextQuestionID");

                    b.Property<int>("Order");

                    b.Property<int>("SurveyId");

                    b.HasKey("ID");

                    b.HasIndex("ChapterID");

                    b.HasIndex("FreetextQuestionID");

                    b.HasIndex("SurveyId");

                    b.ToTable("Survey_FreetextQuestion");
                });

            modelBuilder.Entity("Entities.Survey_MultichoiceQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChapterID");

                    b.Property<int>("MultichoiceQuestionID");

                    b.Property<int>("Order");

                    b.Property<int>("SurveyID");

                    b.HasKey("ID");

                    b.HasIndex("ChapterID");

                    b.HasIndex("MultichoiceQuestionID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Survey_MultichoiceQuestion");
                });

            modelBuilder.Entity("Entities.UsersOptions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Option");

                    b.HasKey("ID");

                    b.ToTable("UsersOptions");
                });

            modelBuilder.Entity("Entities.FreetextAnswer", b =>
                {
                    b.HasOne("Entities.FreetextQuestion", "FreetextQuestion")
                        .WithMany("FreetextAnswer")
                        .HasForeignKey("FreetextQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion_Options", b =>
                {
                    b.HasOne("Entities.MultichoiceQuestion", "MultichoiceQuestion")
                        .WithMany()
                        .HasForeignKey("MultichoiceQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Options", "Options")
                        .WithMany()
                        .HasForeignKey("OptionsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion_OptionsAnswer", b =>
                {
                    b.HasOne("Entities.MultichoiceQuestion", "MultichoiceQuestion")
                        .WithMany()
                        .HasForeignKey("MultichoiceQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Options", "Options")
                        .WithMany()
                        .HasForeignKey("OptionsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.MultichoiceQuestion_UsersOptions", b =>
                {
                    b.HasOne("Entities.MultichoiceQuestion", "MultichoiceQuestion")
                        .WithMany()
                        .HasForeignKey("MultichoiceQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.UsersOptions", "UsersOptions")
                        .WithMany()
                        .HasForeignKey("UsersOptionsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Survey", b =>
                {
                    b.HasOne("Entities.Organisation", "Organisation")
                        .WithMany("Survey")
                        .HasForeignKey("OrganisationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Survey_FreetextQuestion", b =>
                {
                    b.HasOne("Entities.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterID");

                    b.HasOne("Entities.FreetextQuestion", "FreetextQuestion")
                        .WithMany()
                        .HasForeignKey("FreetextQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Survey_MultichoiceQuestion", b =>
                {
                    b.HasOne("Entities.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterID");

                    b.HasOne("Entities.MultichoiceQuestion", "MultichoiceQuestion")
                        .WithMany()
                        .HasForeignKey("MultichoiceQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
