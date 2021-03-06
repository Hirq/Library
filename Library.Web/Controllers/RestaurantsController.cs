using Library.Data.Models;
using Library.Data.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using Library.Web.Models;

namespace Library.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var viewModel = new OpinionFormViewModel
            {
                Restaurants = db.GetAll(),
                //Restaurant = db.GetAll().First(),
            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                return View("NotFound");
            }
            return View(restaurant);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public ActionResult Update(int id)
        {
            var model = db.Get(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Index", "Restaurants");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
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

        public ActionResult IndexOpinion(int id)
        {
            var viewModel = new OpinionFormViewModel
            {
                Restaurant = db.Get(id),
                Opinions = db.GetAllOpinions(id).ToList(),
            };
            return View(viewModel);
        }
    }
}