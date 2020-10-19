﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.Web.Data;

namespace PhoneBook.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201018143737_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("PhoneBook.Web.Model.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EntryType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PhoneBookContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PhoneBookContactId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("PhoneBook.Web.Model.PhoneBookContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PhoneBookContacts");
                });

            modelBuilder.Entity("PhoneBook.Web.Model.Entry", b =>
                {
                    b.HasOne("PhoneBook.Web.Model.PhoneBookContact", null)
                        .WithMany("Entries")
                        .HasForeignKey("PhoneBookContactId");
                });
#pragma warning restore 612, 618
        }
    }
}
