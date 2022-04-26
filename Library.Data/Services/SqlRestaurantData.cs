using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly LibraryDbContext db;

        public SqlRestaurantData(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from Restaurant in db.Restaurants
                   select Restaurant;
        }

        public IEnumerable<Opinion> GetAllOpinions(int id)
        {
            return from opinion in db.Opinions
                   where opinion.RestaurantId == id
                   select opinion;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
