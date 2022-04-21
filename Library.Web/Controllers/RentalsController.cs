using Library.Data.Models;
using Library.Data.Services;
using Library.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{

    public class RentalsController : Controller
    {
        private readonly IRentalData db;
        public RentalsController(IRentalData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }        

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new RentalFormViewModel
            {
                Books = db.GetAllBooks().ToList()
            };
            return View(viewModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RentalFormViewModel viewModel)
        {
            var selectBook = db.GetBook(viewModel.Book);
            selectBook.IsRental = true;

            var rental = new Rental
            {
                Person = viewModel.Person,
                Date = viewModel.Date,
                BookID = viewModel.Book
            };

            if (ModelState.IsValid)
            {
                db.Add(rental);
                db.UpdateBook(selectBook);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = db.Get(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Update(rental);
                return RedirectToAction("Details", new { id = rental.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var rental = db.Get(id);
            var selectBook = db.GetBook(rental.BookID);
            selectBook.IsRental = false;

            db.Delete(id);
            db.UpdateBook(selectBook);
            return RedirectToAction("Index");
        }
        
        
        //private readonly IRentalData db;
        //public RentalsController(IRentalData db)
        //{
        //    this.db = db;
        //}
        //public ActionResult Index()
        //{
        //    var model = db.GetAll();
        //    return View(model);
        //}

        //public ActionResult Details(int id)
        //{
        //    var model = db.Get(id);
        //    if (model == null)
        //    {
        //        return View("NotFound");
        //    }
        //    return View(model);
        //}
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost, ValidateAntiForgeryToken]
        //public ActionResult Create(Rental rental)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Add(rental);
        //        return RedirectToAction("Details", new { id = rental.Id });
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Update(int id)
        //{
        //    var model = db.Get(id);
        //    return View(model);
        //}
        //[HttpPost, ValidateAntiForgeryToken]
        //public ActionResult Update(Rental rental)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Update(rental);
        //        return RedirectToAction("Details", new { id = rental.Id});
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    var model = db.Get(id);
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection form)
        //{
        //    db.Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}