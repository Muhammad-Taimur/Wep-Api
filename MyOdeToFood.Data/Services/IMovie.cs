using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Services
{
    public interface IMovie
    {

        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        //   void Delete(int id);

    }
}
