﻿// <auto-generated />
using System;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191116093509_AddNewAutoIncrementColForTask")]
    partial class AddNewAutoIncrementColForTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<int>("MediaType");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("DAL.Models.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("PhaseOrder");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("DAL.Models.BoardUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BoardId");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<int>("MemberType");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("UserId");

                    b.ToTable("BoardUser");
                });

            modelBuilder.Entity("DAL.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("DAL.Models.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BoardId");

                    b.Property<string>("Color");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("DAL.Models.Phase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BoardId");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Name");

                    b.Property<string>("TaskOrder");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Phase");
                });

            modelBuilder.Entity("DAL.Models.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("DAL.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DAL.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("DAL.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BoardId");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<DateTimeOffset>("DueDate");

                    b.Property<int>("EntityStatus");

                    b.Property<TimeSpan>("Estimation");

                    b.Property<Guid?>("ReporterId");

                    b.Property<Guid>("ReporterUserId");

                    b.Property<TimeSpan>("SpentTime");

                    b.Property<long>("TaskKey")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("ReporterId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("DAL.Models.TaskAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionDescription");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAction");
                });

            modelBuilder.Entity("DAL.Models.TaskAssignee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskAssignee");
                });

            modelBuilder.Entity("DAL.Models.TaskLabel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("LabelId");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskLabel");
                });

            modelBuilder.Entity("DAL.Models.TimeLineEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Event");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TimeLineEvent");
                });

            modelBuilder.Entity("DAL.Models.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<bool>("Finished");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTimeOffset?>("AllowTokensSince");

                    b.Property<string>("AvatarUrl");

                    b.Property<DateTimeOffset>("BirthDate");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<string>("Location");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<Guid>("PositionId");

                    b.Property<string>("SocialLink");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DAL.Models.UserSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("SkillId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkill");
                });

            modelBuilder.Entity("DAL.Models.WorkLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("Amount");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<DateTimeOffset>("DateLog");

                    b.Property<string>("Description");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("TaskId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkLog");
                });

            modelBuilder.Entity("DAL.Models.Attachment", b =>
                {
                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.BoardUser", b =>
                {
                    b.HasOne("DAL.Models.Board", "Board")
                        .WithMany("BoardUsers")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Comment", b =>
                {
                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Phase", b =>
                {
                    b.HasOne("DAL.Models.Board", "Board")
                        .WithMany("Phases")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Task", b =>
                {
                    b.HasOne("DAL.Models.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "Reporter")
                        .WithMany("CreatedTasks")
                        .HasForeignKey("ReporterId");
                });

            modelBuilder.Entity("DAL.Models.TaskAction", b =>
                {
                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany("TaskActions")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("TaskActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.TaskAssignee", b =>
                {
                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany("TaskAssignees")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("TaskAssignees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.TaskLabel", b =>
                {
                    b.HasOne("DAL.Models.Label", "Label")
                        .WithMany("TaskLabels")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany("TaskLabels")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.TimeLineEvent", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("TimeLineEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Todo", b =>
                {
                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.HasOne("DAL.Models.Position", "Position")
                        .WithMany("Users")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.UserRole", b =>
                {
                    b.HasOne("DAL.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.UserSkill", b =>
                {
                    b.HasOne("DAL.Models.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.WorkLog", b =>
                {
                    b.HasOne("DAL.Models.Task", "Task")
                        .WithMany("WorkLogs")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("WorkLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
