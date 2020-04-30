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
        
        public HttpResponseMessage Get()
        {

            //using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            //return sd.Movies;
            //   return db.GetAll();

            MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();

            var query = from m in sd.Movies
                        join a in sd.Actors on m.MovieId equals a.MovieId into table2
                        from a in table2.DefaultIfEmpty()
                        select new
                        {
                            Movies =m,
                            Actors = a,
                           //a.Movie.MovieName,
                        };

            // return Ok (query);
            return Request.CreateResponse(HttpStatusCode.OK, query);

        }
    }
}
