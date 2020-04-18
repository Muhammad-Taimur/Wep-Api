using MyOdeToFood.Data;
using MyOdeToFood.Data.Models;
using MyOdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyOdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;
        private readonly IDhabaData dd;

        public RestaurantsController(IRestaurantData db, IDhabaData dd)
        {
            this.db = db;
            this.dd = dd;
        }

        //[HttpGet]
        //public IEnumerable<Dhaba> Load()
        //{
        //    var model = dd.GetAll();
        //    return model;
        //}


        //public IEnumerable<Restaurant> Get()
        //{
        //     //var model = db.GetAll();
        //     //return model;
        //     MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();
        //     return sd.Restaurants;
        //}

        //public IHttpActionResult Get()
        public IHttpActionResult GetAll()
        {
            MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();

            //List<Restaurant> lrestaurant = sd.Restaurants.ToList();
            //List<Dhaba> ldhaba= sd.Dhabas.ToList();

            //var query = from r in sd.Restaurants
            //            join d in sd.Dhabas on r.Id equals d.Id into table1
            //            from d in table1.DefaultIfEmpty()
            //            select new 
            //            {
            //                Restaurant = r ,
            //                Dhaba = d
            //
            //            };
            //            
            //                //Restaurant = r, Dhaba = d };
            //return Ok (query);

            //var query = sd.Restaurants.FirstOrDefault();
            //return Ok (query);



            var books = from r in sd.Restaurants
                        join d in sd.Dhabas on r.Id equals d.Id
                        select new 
                        {
                            Restaurant = r, Dhaba = d,
                            Id = d.Id,
                            Name = r.Name,
                                                   };

            //Restaurant = r, Dhaba = d };

            return Ok(books);
            }

}


    }

