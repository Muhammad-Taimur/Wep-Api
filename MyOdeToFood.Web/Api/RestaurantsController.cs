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
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MyOdeToFood.Web.Api
{
    //This enable Cors Api only for this contraller
    [EnableCorsAttribute("*","*","*")]
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

        //public IEnumerable <Restaurant> Get()

            //[DisableCors] this will Disable the API Cors for this method.
        public HttpResponseMessage Get(string city = "All")
        {
            MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();

            switch (city.ToLower()) {

                case "all":
            var query = from r in sd.Restaurants
                        join d in sd.Dhabas on r.Id equals d.Id into table1
                        from d in table1.DefaultIfEmpty()
                        select new
                        {
                            Restaurant = r,
                            Dhaba = d
                        };

            // return Ok (query);
            return Request.CreateResponse(HttpStatusCode.OK, query);

                case "dublin":

                    var query1 = from r in sd.Restaurants
                                join d in sd.Dhabas on r.Id equals d.Id into table1
                                from d in table1.DefaultIfEmpty()
                                select new
                                {
                                    Restaurant = r,
                                    Dhaba = d
                                };
                    
                    return Request.CreateResponse(HttpStatusCode.OK,
                        query1.Where(c => c.Restaurant.City == "Dublin"));



                case "lahore":

                    var query2 = from r in sd.Restaurants
                                 join d in sd.Dhabas on r.Id equals d.Id into table1
                                 from d in table1.DefaultIfEmpty()
                                 select new
                                 {
                                     Restaurant = r,
                                     Dhaba = d
                                 };


                    return Request.CreateResponse(HttpStatusCode.OK,
                        query2.Where(c => c.Restaurant.City == "lahore"));


                case "karachi":
                    var query3 = from r in sd.Restaurants
                                 join d in sd.Dhabas on r.Id equals d.Id into table1
                                 from d in table1.DefaultIfEmpty()
                                 select new
                                 {
                                     Restaurant = r,
                                     Dhaba = d
                                 };
                    
                    return Request.CreateResponse(HttpStatusCode.OK,
                        query3.Where(c => c.Restaurant.City == "karachi"));


                default:
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                "Value for City must be Lahore or Dublin. " + city + " is invalid");

            }

                //Restaurant = r, Dhaba = d };
                //return sd.Restaurants.ToList();
        }

            //var query = sd.Restaurants.FirstOrDefault();
            //return Ok (query);



            //var books = from r in sd.Restaurants
            //            join d in sd.Dhabas on r.Id equals d.Id
            //            
            //            select new JoinClass
            //            {
            //                Restaurant = r, Dhaba = d,
            //                Id = d.Id,
            //                Name = r.Name
            //            };
            //
            ////Restaurant = r, Dhaba = d };
            //
            //return Ok(books);
        
        [HttpGet]
        public IHttpActionResult  Get (int id)
        {
            MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();
            
            var query = from r in sd.Restaurants
                            join d in sd.Dhabas on r.Id equals d.Id into table1
                            from d in table1.DefaultIfEmpty()
                            select new
                            {
                                Restaurant = r,
                                Dhaba = d

                            };

                return Ok(query.FirstOrDefault(r => r.Restaurant.Id == id));
//                return sd.Restaurants.FirstOrDefault(r => r.Id == id);
                
            

        }

        public void Post ([FromBody] Restaurant restaurant)
        {
            using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            {
                sd.Restaurants.Add(restaurant);
                sd.SaveChanges();
            }
    
        }

        public void Delete (int id)
        {

            using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            {
                sd.Restaurants.Remove(sd.Restaurants.FirstOrDefault(r => r.Id == id));
                sd.SaveChanges();
            }
        }

        public void Put (int id, [FromBody] Restaurant restaurant)
        {
            using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            {
                var entity = sd.Restaurants.FirstOrDefault(r => r.Id == id);
                entity.CuisineType = restaurant.CuisineType;
                entity.City = restaurant.City;
                entity.Country= restaurant.Country;
                sd.SaveChanges();
            }

        }

}


    }

