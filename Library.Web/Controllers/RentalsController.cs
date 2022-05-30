using Library.Data.Models;
using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Data.Services.Interfaces;

namespace Library.Web.Controllers
{

    public class RentalsController : Controller
    {
        private readonly IRentalData _rentalService;
        private readonly IBookData _bookService;

        public RentalsController(IRentalData rentalService, IBookData bookService)
        {
            _rentalService = rentalService;
            _bookService = bookService;
        }
        public ActionResult Index()
        {
            var model = new RentalListViewModel
            {
                Rentals = _rentalService.GetAllRentals().ToList(),
                CountBooks = _bookService.Count(),
                CountRentals = _rentalService.Count(),
                
            };
            return View(model);

        }        

        public ActionResult Details(int id)
        {
            var model = _rentalService.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new RentalFormViewModel
            {
                Books = _rentalService.GetAllBooksNotRental().ToList()
            };
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RentalFormViewModel model)
        {
            var selectBook = _rentalService.GetBook(model.Book);
            selectBook.IsRental = true;

            var rental = new Rental
            {
                Person = model.Person,
                Date = model.Date,
                BookID = model.Book
            };

            if (ModelState.IsValid)
            {
                _rentalService.Add(rental);
                _rentalService.UpdateBook(selectBook);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _rentalService.Get(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _rentalService.Update(rental);
                return RedirectToAction("Details", new { id = rental.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _rentalService.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var rental = _rentalService.Get(id);
            var selectBook = _rentalService.GetBook(rental.BookID);
            selectBook.IsRental = false;

            _rentalService.Delete(id);
            _rentalService.UpdateBook(selectBook);
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