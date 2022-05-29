using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Data.Services.Interfaces;

namespace Library.Data.Services
{
    public class SqlBookData : IBookData
    {
        private readonly LibraryDbContext db;

        public SqlBookData(LibraryDbContext db)
        {
            this.db = db;
        }
        public void Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public int Count()
        {
            return db.Books.Count();
        }

        public void Delete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public Book Get(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return from book in db.Books
                   select book;
        }

        public Rental GetRental(int id)
        {
            return db.Rentals.FirstOrDefault(x => x.BookID == id);
        }

        public void Update(Book book)
        {
            var entry = db.Entry(book);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
