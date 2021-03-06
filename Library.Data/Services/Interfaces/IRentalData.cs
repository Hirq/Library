using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Services.Interfaces
{
    public interface IRentalData
    {
        IEnumerable<Rental> GetAllRentals();
        Rental Get(int id);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(int id);
        IEnumerable<Book> GetAllBooksNotRental();
        Book GetBook(int id);
        void UpdateBook(Book book);
        int Count();

    }
}
