using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Services
{
    public class InMemoryBookData : IBookData
    {
        List<Book> books;

        public InMemoryBookData()
        {
            books = new List<Book>()
            {
                new Book{ Id = 0, Name = "Galapagos", Autor = "Kurt Vonnegut", IsRental = false, TypeBook = BookType.science },
                new Book{ Id = 1, Name = "Rzeźnia 44", Autor = "Kurt Vonnegut", IsRental = false, TypeBook = BookType.horror },
                new Book{ Id = 2, Name = "Ogniem i Mieczem", Autor = "Henryk Sienkiewicz", IsRental = true, TypeBook = BookType.historial },
            };
        }

        public void Add(Book book)
        {
            books.Add(book);
            book.Id = books.Max(b => b.Id) + 1;
        }

        public void Delete(int id)
        {
            var book = Get(id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
        public Book Get(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books.OrderBy(b => b.Name);
        }

        public void Update(Book book)
        {
            var existing = Get(book.Id);
            if (existing != null)
            {
                existing.Autor = book.Autor;
                existing.Name = book.Name; 
                existing.IsRental = book.IsRental; 
                existing.TypeBook = book.TypeBook;  
            }
        }
    }
}
