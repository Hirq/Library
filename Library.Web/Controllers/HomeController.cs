using Library.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        IBookData db;
        public HomeController(IBookData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}