﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using examination_system.DB;

#nullable disable

namespace examination_system.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    partial class ExamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student_Subject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Student_Subject", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultId"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ResultId");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Results", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.StudentAnswer", b =>
                {
                    b.Property<int>("StudentAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentAnswerId"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("AnswerId1")
                        .HasColumnType("int");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId1")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentAnswerId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AnswerId1");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionId1");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAnswers", (string)null);
                });

            modelBuilder.Entity("examination_system.DB.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("Student_Subject", b =>
                {
                    b.HasOne("examination_system.DB.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("examination_system.DB.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("examination_system.DB.Answer", b =>
                {
                    b.HasOne("examination_system.DB.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("examination_system.DB.Exam", b =>
                {
                    b.HasOne("examination_system.DB.Subject", "Subject")
                        .WithMany("Exams")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("examination_system.DB.Question", b =>
                {
                    b.HasOne("examination_system.DB.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("examination_system.DB.Result", b =>
                {
                    b.HasOne("examination_system.DB.Exam", "Exam")
                        .WithMany("Results")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("examination_system.DB.Student", "Student")
                        .WithMany("Results")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("examination_system.DB.StudentAnswer", b =>
                {
                    b.HasOne("examination_system.DB.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("examination_system.DB.Answer", null)
                        .WithMany("StudentAnswers")
                        .HasForeignKey("AnswerId1");

                    b.HasOne("examination_system.DB.Exam", "Exam")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("examination_system.DB.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("examination_system.DB.Question", null)
                        .WithMany("StudentAnswers")
                        .HasForeignKey("QuestionId1");

                    b.HasOne("examination_system.DB.Student", "Student")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Exam");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("examination_system.DB.Answer", b =>
                {
                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("examination_system.DB.Exam", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Results");

                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("examination_system.DB.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("examination_system.DB.Student", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("StudentAnswers");

                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("examination_system.DB.Subject", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
