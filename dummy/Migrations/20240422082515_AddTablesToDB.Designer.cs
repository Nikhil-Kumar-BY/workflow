﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dummy.Data;

#nullable disable

namespace dummy.Migrations
{
    [DbContext(typeof(pgdbContext))]
    [Migration("20240422082515_AddTablesToDB")]
    partial class AddTablesToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("dummy.Models.Shift", b =>
                {
                    b.Property<int>("shiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("shift_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("shiftId"));

                    b.Property<int?>("requested_user_id")
                        .HasColumnType("integer")
                        .HasColumnName("requested_user_id");

                    b.Property<DateTime>("shiftEndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_time");

                    b.Property<string>("shiftJob")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job");

                    b.Property<DateTime>("shiftStartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_time");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("shiftId");

                    b.HasIndex("user_id");

                    b.ToTable("shift_table");
                });

            modelBuilder.Entity("dummy.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userId"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_email");

                    b.Property<int>("gender")
                        .HasColumnType("integer")
                        .HasColumnName("user_gender");

                    b.Property<DateTime?>("lastLoginTimeStamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_login_time_stamp");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_password");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<int>("userRole")
                        .HasColumnType("integer")
                        .HasColumnName("user_role");

                    b.HasKey("userId");

                    b.ToTable("user_table");
                });

            modelBuilder.Entity("dummy.Models.Shift", b =>
                {
                    b.HasOne("dummy.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
