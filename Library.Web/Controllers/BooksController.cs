using Library.Data.Models;
using Library.Data.Services;
using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Data.Services.Interfaces;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBookData _bookService;
        public BooksController(IBookData bookService)
        {
            //db = new InMemoryBookData(); // nie dziala wtedy obsługa create,delete,udpate, bo po kazdej akcji zwracalo nowa liste.
            this._bookService = bookService;
        }
        public ActionResult Index()
        {
            var model = new BookListViewModel
            {
                Books = _bookService.GetAll(),
                CountBooks = _bookService.Count()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult RentalList()
        {
            var model = _bookService.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var book = _bookService.Get(id);
            var rental = _bookService.GetRental(book.Id);
            if (book == null)
            {
                return View("NotFound");
            }
            if (rental == null)
            {
                rental = new Rental
                {
                    Book = book,
                };
            }
            return View(rental);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }    
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if(ModelState.IsValid)
            {
                _bookService.Add(book);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var book = _bookService.Get(id);
            var rental = _bookService.GetRental(id);

            var model = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Autor = book.Autor,
                IsRental = book.IsRental,
                TypeBook = book.TypeBook,
            };
            if (rental != null)
            {
                model.Person = rental.Person;
                model.Date = rental.Date;
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(BookViewModel model)
        {
            Book book = new Book
            {
                Id = model.Id,
                Name = model.Name,
                Autor = model.Autor,
                TypeBook= model.TypeBook,
            };
            if (ModelState.IsValid)
            {
                _bookService.Update(book);
                return RedirectToAction("Index", "Books");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _bookService.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}