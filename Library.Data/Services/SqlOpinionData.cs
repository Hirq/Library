using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Services.Interfaces;

namespace Library.Data.Services
{
    public class SqlOpinionData : IOpinionData
    {
        private readonly LibraryDbContext db;
        public SqlOpinionData(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Add(Opinion opinion)
        {
            db.Opinions.Add(opinion);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var opinion = db.Opinions.Find(id);
            db.Opinions.Remove(opinion);
            db.SaveChanges();
        }

        public Opinion Get(int id)
        {
            return db.Opinions.FirstOrDefault(opinion => opinion.Id == id);
        }

        public IEnumerable<Opinion> GetAll(int id)
        {
            return from opinion in db.Opinions where opinion.RestaurantId == id 
                   select opinion;
        }

        public Restaurant GetRestaurant(int id)
        {
            return db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
        }

        public void Update(Opinion opinion)
        {
            var entry = db.Entry(opinion);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
