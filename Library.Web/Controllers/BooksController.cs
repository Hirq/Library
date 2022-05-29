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
        private readonly IBookData db;
        public BooksController(IBookData db)
        {
            //db = new InMemoryBookData(); // nie dziala wtedy obsługa create,delete,udpate, bo po kazdej akcji zwracalo nowa liste.
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = new BookListViewModel
            {
                Books = db.GetAll(),
                CountBooks = db.Count()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult RentalList()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var book = db.Get(id);
            var rental = db.GetRental(book.Id);
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
                db.Add(book);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var book = db.Get(id);
            var rental = db.GetRental(id);

            var model = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Autor = book.Autor,
                IsRental = book.IsRental,
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
        public ActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book);
                return RedirectToAction("Details", new { id = book.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}