using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Models
{
    public class Movie
    {
        [Key]
        public int MovieId{ get; set; }
        public string  MovieName { get; set; }
        //List of Actor Name and ID

       // [ForeignKey("Actor")]
        public ICollection<Actor> Actor { get; set; }
    }
}
