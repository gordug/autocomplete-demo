﻿// <auto-generated />
using Autocomplete.Demo.Data.DeviceUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autocomplete.Demo.Migrations
{
    [DbContext(typeof(DeviceUserDbContext))]
    [Migration("20240622073247_AddDeviceUserContext")]
    partial class AddDeviceUserContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Autocomplete.Demo.Data.DeviceUser.DeviceUserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EnrolmentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KeypadId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("device_users");
                });
#pragma warning restore 612, 618
        }
    }
}
