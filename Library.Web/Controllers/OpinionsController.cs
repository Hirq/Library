using Library.Data.Services.Interfaces;
using Library.Data.Models;
using System.Web.Mvc;
using Library.Web.Models;

namespace Library.Web.Controllers
{
    public class OpinionsController : Controller
    {
        private readonly IOpinionData db;
        public OpinionsController(IOpinionData db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            var restaurant = db.GetRestaurant(id);
            var opinion = new Opinion
            {
                RestaurantId = id,
                Restaurant = restaurant
            };
            return View(opinion);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(OpinionFormViewModel viewModel)
        {
            var opinion = new Opinion
            {
                Title = viewModel.Title,
                Text = viewModel.Text,
                Who = viewModel.Who,
                GradeFood = viewModel.GradeFood,
                GradeDrink = viewModel.GradeDrink,
                RestaurantId = viewModel.RestaurantId
            };

            if (ModelState.IsValid)
            {
                db.Add(opinion);
                return RedirectToAction(
                    actionName: "IndexOpinion",
                    controllerName: "Restaurants",
                    routeValues: new { id = viewModel.RestaurantId }
                    );

            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, int idRestaurant, FormCollection form)
        {
            var restaurant = db.GetRestaurant(idRestaurant);
            db.Delete(id);
            return RedirectToAction(
                actionName: "IndexOpinion",
                controllerName: "Restaurants",
                routeValues: new { id = restaurant.Id }
                );
        }

    }
}