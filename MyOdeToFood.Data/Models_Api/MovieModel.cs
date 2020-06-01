using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Models_Api
{
    public class MovieModel
    {
       // public int MovieId { get; set; }

        public string MovieName { get; set; }
         public List<ActorModel> Actor { get; set; }


    }
}
