using MyOdeToFood.Data.Models;
using MyOdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyOdeToFood.Web.Api
{
    public class MoviesController : ApiController
    {
        private readonly IMovie db;
        private readonly IActor dd;

        public MoviesController(IMovie db, IActor dd) {
            this.db = db;
            this.dd = dd;
        }
        
        //public IEnumerable<Movie> Get()
        //{
        //    MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();
        //    return sd.Movies;
        //}
       
        public HttpResponseMessage Get()
        {
        
            //using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            //return sd.Movies;
            //   return db.GetAll();
        
            MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();

            var query = from m in sd.Movies.Include("Actor").ToList()
                        join a in sd.Actors on m.MovieId equals a.MovieId into table1
                        from a in table1.DefaultIfEmpty()
                        select new
                        {
                           Movies =m,
                          //m.Actor
                           //m.MovieName,
                            //a.ActorName
                            //Actors = a,
                           //a.Movie.MovieName,
                        };
            var query1 = from a in sd.Actors
                         select new { a.ActorName};
            
            Object obj= (query , query1);

          var newquery = sd.Movies.Include("Actor").OrderBy(a => a.MovieId).ToList();


            //var travelCompany = objContext.TravelCompanyDetails.Include(t => t.CarDetails)
            //    .OrderBy(a => a.TravelCompanyID).ToList();

// travelCompany = objContext.TravelCompanyDetails.include("CarDetails")
//.OrderBy(a => a.TravelCompanyID).ToList();
 
            // return Ok (query);
            return Request.CreateResponse(HttpStatusCode.OK, query);
        
        }
    }
}
