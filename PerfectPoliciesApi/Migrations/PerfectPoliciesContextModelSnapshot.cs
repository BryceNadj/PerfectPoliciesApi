﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfectPoliciesApi.Entities;

namespace PerfectPoliciesApi.Migrations
{
    [DbContext(typeof(PerfectPoliciesContext))]
    partial class PerfectPoliciesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("OptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            OptionId = 1,
                            IsCorrect = false,
                            OptionText = "L-S-T-E-R",
                            Order = "A",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 2,
                            IsCorrect = false,
                            OptionText = "16",
                            Order = "B",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 3,
                            IsCorrect = true,
                            OptionText = "R-E-D",
                            Order = "C",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 4,
                            IsCorrect = false,
                            OptionText = "Purple",
                            Order = "A",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 5,
                            IsCorrect = true,
                            OptionText = "Orange",
                            Order = "B",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 6,
                            IsCorrect = false,
                            OptionText = "Pineapple",
                            Order = "C",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 7,
                            IsCorrect = false,
                            OptionText = "I don't know",
                            Order = "D",
                            QuestionId = 2
                        });
                });

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            QuestionText = "How do you spell \"Red\"?",
                            QuizId = 1,
                            Topic = "English"
                        },
                        new
                        {
                            QuestionId = 2,
                            QuestionText = "What colour is a carrot?",
                            QuizId = 1,
                            Topic = "English"
                        });
                });

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("PassingGrade")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            QuizId = 1,
                            Author = "Me",
                            DateCreated = new DateTime(2022, 3, 11, 7, 0, 58, 456, DateTimeKind.Utc).AddTicks(1968),
                            PassingGrade = 5,
                            Title = "BeetleJuice",
                            Topic = "English"
                        });
                });

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Option", b =>
                {
                    b.HasOne("PerfectPoliciesApi.Entities.Question", "Question")
                        .WithMany("Option")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Question", b =>
                {
                    b.HasOne("PerfectPoliciesApi.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Question", b =>
                {
                    b.Navigation("Option");
                });

            modelBuilder.Entity("PerfectPoliciesApi.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
