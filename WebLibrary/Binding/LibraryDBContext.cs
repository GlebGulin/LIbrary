using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Binding
{
   
    public class LibraryDBContext : DbContext
    {
        public DbSet<Author> dataAuthor { get; set; }
        public DbSet<Book> dataBook { get; set; }
        public DbSet<Order> dataOrder { get; set; }
        public DbSet<Registration> dataRegUser { get; set; }
        
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    NameAuthor = "Автор 1"
                },
                new Author
                {
                    Id = 2,
                    NameAuthor = "Автор 2"
                },
                new Author
                {
                    Id = 3,
                    NameAuthor = "Автор 3"
                }

            );
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   NameBook = "Книга 1",
                   AuthorId = 1,
                   AuthorName = "Автор",
                   TotalQuantity = 20,
                   RealQuantity = 19
               },
               new Book
               {
                   Id = 2,
                   NameBook = "Книга 2",
                   AuthorId = 2,
                   AuthorName = "Автор 2",
                   TotalQuantity = 10,
                   RealQuantity = 9
               },
               new Book
               {
                   Id = 3,
                   NameBook = "Книга 3",
                   AuthorId = 3,
                   AuthorName = "Автор 3",
                   TotalQuantity = 5,
                   RealQuantity = 4
               }

           );
            modelBuilder.Entity<Registration>().HasData(
               new Registration
               {
                   Id = 1,
                   UserName = "Иван",
                   Email = "ivanivan@gmail.com",
                   Password = "11111111",
                   City = "Город 1"
               },
               new Registration
               {
                   Id = 2,
                   UserName = "Дмитрий",
                   Email = "dimdim@gmail.com",
                   Password = "11111111",
                   City = "Город 2"
               },
               new Registration
               {
                   Id = 3,
                   UserName = "Александр",
                   Email = "alexandr@gmail.com",
                   Password = "11111111",
                   City = "Город 3"
               }

           );
            modelBuilder.Entity<Order>().HasData(
              new Order
              {
                  Id = 1,
                  BookId = 1,
                  BookName = "Книга 1",
                  RegistrationId = 1,
                  RegUserName = "Иван",
                  DateOrder = new DateTime()
              },
              new Order
              {
                  Id = 2,
                  BookId = 2,
                  BookName = "Книга 2",
                  RegistrationId = 2,
                  RegUserName = "Дмитрий",
                  DateOrder = new DateTime()
              },
              new Order
              {
                  Id = 3,
                  BookId = 3,
                  BookName = "Книга 3",
                  RegistrationId = 3,
                  RegUserName = "Александр",
                  DateOrder = new DateTime()
              }

          );

        }
    }
   
}
