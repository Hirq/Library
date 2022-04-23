﻿using Library.Data.Models;
using Library.Data.Services;
using Library.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookData db;
        //IBookData db;
        public BooksController(IBookData db)
        {
            //db = new InMemoryBookData(); // nie dziala wtedy obsługa create,delete,udpate, bo po kazdej akcji zwracalo nowa liste.
            this.db = db;
        }
        // GET: Books
        public ActionResult Index()
        {
            var model = db.GetAll();
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
            //var viewModel = new RentalFormViewModel
            //{
            //    //Name = book.Name,
            //    //Autor = book.Autor,
            //    //TypeBook = book.TypeBook,
            //    //IsRental = book.IsRental,
            //    Person = rental.Person,
            //    Book = rental.BookID
            //};
            //return View(viewModel);

            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
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
                return RedirectToAction("Details", new { id = book.Id });
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = db.Get(id);
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