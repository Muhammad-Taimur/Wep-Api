using AutoMapper;
using MyOdeToFood.Data.Models;
using MyOdeToFood.Data.Services;
using MyOdeToFood.Data.Models_Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;

namespace MyOdeToFood.Web.Api
{
    public class MoviesController : ApiController
    {
        private readonly IMovie db;
        private readonly IActor dd;
        private readonly IMapper mapper;

        public MoviesController(IMovie db ,IActor dd, IMapper mapper) {
            this.db = db;
            this.dd = dd;
            this.mapper = mapper;
        }
        
        public IHttpActionResult Get()
        {
            MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();
            //return
            var result=  sd.Movies;
            var result1 = sd.Actors;

            Object obj = (result, result1);
            var result11 = db.GetAll();
            var res = dd.GetAll();

            var mappedResult = mapper.Map<IEnumerable<MovieModel>>(result.Include("Actor").OrderBy(a => a.MovieName));
            
            Object obb = (mappedResult);

            return Ok(obb);
        }

        
        public IHttpActionResult Post(Movie movie)
        {

            try { 
                MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();

                //create movie object
                var mov = new Movie();

                //add movie name as get value from API
                mov.MovieName = movie.MovieName;

                //add actor as get value from API
                mov.Actor = movie.Actor;
                
                //save in DB
                sd.Movies.Add(mov);


                sd.SaveChanges();

                //convert get inputted value and set ad Movie model
                var newmodel = mapper.Map<MovieModel>(movie);

                return Created(" ", newmodel);
            }
             
             catch(Exception ex)
             {
                  throw new HttpException("",ex);
                 
             }
            //var model = mapper.Map<Movie>(movieModel);
            //
            //db.Add(model);
            //
            //var newModel = mapper.Map<MovieModel>(model);
            //
            //var location = Url.Link("", new { newModel = model.MovieName});
            //

            //using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            //{
            //    sd.Movies.Add(movie);
            //    sd.Actors.Add(actor);
            //    sd.SaveChanges();
            //}
            //Object obj = (movie, actor);
            //return Ok(location);

        }

        // public HttpResponseMessage Get()
        // {
        //     
        //
        // }

        //public IEnumerable<Movie> Get()
        //{
        //    MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();
        //    return sd.Movies;
        //}

        /* public HttpResponseMessage Get()
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

 // travelCompany = objContext.TravelCompanyDetails.include("CarDetails")
 //.OrderBy(a => a.TravelCompanyID).ToList();

             // return Ok (query);
             return Request.CreateResponse(HttpStatusCode.OK, newquery);

         }
    */


    }
}
