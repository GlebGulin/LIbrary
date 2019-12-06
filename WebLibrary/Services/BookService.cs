using Binding;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        bool Add(Book model);

        bool Update(Book model);
        bool Delete(int id);
        Book Getid(int id);
    }
    public class BookService : IBookService
    {
        public readonly LibraryDBContext _bookDbContext;

        public BookService(LibraryDBContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<Book> GetAll()
        {

            var result = new List<Book>();
            try
            {
                result = _bookDbContext.dataBook.ToList();


            }
            catch (System.Exception)
            {

            }
            return result;
        }
        public bool Add(Book model)
        {
            try
            {
                _bookDbContext.Add(model);
                _bookDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _bookDbContext.Entry(new Book { Id = id }).State = EntityState.Deleted;
                _bookDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }



        public Book Getid(int id)
        {
            var result = new Book();
            try
            {
                result = _bookDbContext.dataBook.Single(x => x.Id == id);


            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Update(Book model)
        {
            try
            {

                var originalModel = _bookDbContext.dataBook.Single(x => x.Id == model.Id);

                originalModel.NameBook = model.NameBook;
                originalModel.RealQuantity = model.RealQuantity;
                originalModel.TotalQuantity = model.TotalQuantity;
                originalModel.AuthorName = model.AuthorName;
                originalModel.AuthorId = model.AuthorId;


                _bookDbContext.Update(originalModel);
                _bookDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
