using AutoMapper;
using MyOdeToFood.Data.Models_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

           CreateMap<Actor, ActorModel>().ReverseMap();
            CreateMap<Movie, MovieModel>().ReverseMap();


                // .ForMember(MovieModel=> MovieModel.ActorName,
                //opt => opt.MapFrom(Actor => Actor.ActorName.ToList()));



            //.ForMember(MovieModel=> MovieModel.Actor,
            //opt=> opt.MapFrom(Movie=> Movie.Actor.ToList())); 



            //  .ForMember(MovieModel => MovieModel.Actor,
            //           opt => opt.MapFrom(Movie => Movie.Actor.Where(MovieModel => MovieModel.MovieId ==Movie.MovieId)))
            //.ForMember(m => m.Actor, o => o.MapFrom(a => a.Actor.Where(b => b.MovieId == a.MovieId)))
            //.ForMember(x => x.MovieName, p=> p.MapFrom(j => j.MovieName))
            //.ReverseMap();
            //CreateMap<Actor, ActorModel>().ReverseMap();
            //.ForMember(m => m.Actor, opt => opt.MapFrom(a => a.Actor.Select(j => j.Id == a.MovieId)));


            //CreateMap<Actor, ActorModel>()
            //     .ForMember(m => m.Actor, o => o.MapFrom(a => a.Actor.Where(b => b.MovieId == a.MovieId)
            //.Select(n => n.ActorName)))
            //.ReverseMap();
            //        .ForMember(m => m.ActorName, opt => opt.MapFrom(a => a.ActorName))        
            //                .ReverseMap();
        }
    }
}
