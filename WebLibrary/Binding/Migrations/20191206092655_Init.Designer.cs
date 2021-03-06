﻿// <auto-generated />
using System;
using Binding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Binding.Migrations
{
    [DbContext(typeof(LibraryDBContext))]
    [Migration("20191206092655_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAuthor");

                    b.HasKey("Id");

                    b.ToTable("dataAuthor");

                    b.HasData(
                        new { Id = 1, NameAuthor = "Автор 1" },
                        new { Id = 2, NameAuthor = "Автор 2" },
                        new { Id = 3, NameAuthor = "Автор 3" }
                    );
                });

            modelBuilder.Entity("Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("AuthorName");

                    b.Property<string>("NameBook");

                    b.Property<int>("RealQuantity");

                    b.Property<int>("TotalQuantity");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("dataBook");

                    b.HasData(
                        new { Id = 1, AuthorId = 1, AuthorName = "Автор", NameBook = "Книга 1", RealQuantity = 20, TotalQuantity = 20 },
                        new { Id = 2, AuthorId = 2, AuthorName = "Автор 2", NameBook = "Книга 2", RealQuantity = 10, TotalQuantity = 10 },
                        new { Id = 3, AuthorId = 3, AuthorName = "Автор 3", NameBook = "Книга 3", RealQuantity = 5, TotalQuantity = 5 }
                    );
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<string>("BookName");

                    b.Property<DateTime>("DateOrder");

                    b.Property<string>("RegUserName");

                    b.Property<int>("RegistrationId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("dataOrder");

                    b.HasData(
                        new { Id = 1, BookId = 1, BookName = "Книга 1", DateOrder = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), RegUserName = "Иван", RegistrationId = 1 },
                        new { Id = 2, BookId = 2, BookName = "Книга 2", DateOrder = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), RegUserName = "Дмитрий", RegistrationId = 2 },
                        new { Id = 3, BookId = 3, BookName = "Книга 3", DateOrder = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), RegUserName = "Александр", RegistrationId = 3 }
                    );
                });

            modelBuilder.Entity("Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("dataRegUser");

                    b.HasData(
                        new { Id = 1, City = "Город 1", Email = "ivanivan@gmail.com", Password = "11111111", UserName = "Иван" },
                        new { Id = 2, City = "Город 2", Email = "dimdim@gmail.com", Password = "11111111", UserName = "Дмитрий" },
                        new { Id = 3, City = "Город 3", Email = "alexandr@gmail.com", Password = "11111111", UserName = "Александр" }
                    );
                });

            modelBuilder.Entity("Models.Book", b =>
                {
                    b.HasOne("Models.Author", "author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.Book", "TakenBook")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Registration", "TakenUserBook")
                        .WithMany()
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
