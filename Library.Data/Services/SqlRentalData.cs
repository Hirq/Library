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
    public class SqlRentalData : IRentalData
    {
        private readonly LibraryDbContext db;
        public SqlRentalData(LibraryDbContext db)
        {
            this.db = db;
        }
        public void Add(Rental rental)
        {
            db.Rentals.Add(rental);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
            db.SaveChanges();
        }

        public Rental Get(int id)
        {
            return db.Rentals.FirstOrDefault(rental => rental.Id == id);
        }

        public IEnumerable<Rental> GetAllRentals()
        {
            return from rental in db.Rentals
                   select rental;
        }

        public IEnumerable<Book> GetAllBooksNotRental()
        {
            return from book in db.Books
                   where book.IsRental == false
                   select book;
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(book => book.Id == id);
        }

        public void Update(Rental rental)
        {
            var entry = db.Entry(rental);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var entry = db.Entry(book);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public int Count()
        {
            return db.Rentals.Count();
        }
    }
}
