using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData, IDhabaData
    {
        private readonly MyOdeToFoodDbContext db;

        public SqlRestaurantData(MyOdeToFoodDbContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            
        }

        public void Add(Dhaba dhaba)
        {
            db.Dhabas.Add(dhaba);
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
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Update(Dhaba dhaba)
        {
            var entry = db.Entry(dhaba);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        Dhaba IDhabaData.Get(int id)
        {

            return db.Dhabas.FirstOrDefault(r => r.Id == id);
        }

        IEnumerable<Dhaba> IDhabaData.GetAll()
        {
            return db.Dhabas;
        }
    }
}
