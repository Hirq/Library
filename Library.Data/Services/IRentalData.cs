using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Services
{
    public interface IRentalData
    {
        IEnumerable<Rental> GetAll();
        Rental Get(int id);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(int id);
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
        void UpdateBook(Book book);

    }
}
