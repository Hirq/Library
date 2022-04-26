using Library.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class OpinionsController : Controller
    {
        private readonly IOpinionData db;
        public OpinionsController(IOpinionData db)
        {
            this.db = db;
        }
        public ActionResult Index(int id)
        {
            var model = db.GetAll(id);
            return View(model);
        }
    }
}