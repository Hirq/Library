using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public IEnumerable<Rental> GetAll()
        {
            return from rental in db.Rentals
                   select rental;
        }

        public void Update(Rental rental)
        {
            var entry = db.Entry(rental);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
