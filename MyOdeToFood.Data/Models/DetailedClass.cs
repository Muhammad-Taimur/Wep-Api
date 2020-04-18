using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Models
{
   public class DetailedClass
    {

        public int Id{ get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        public Cuisine CuisineType { get; set; }

        public string City { get; set; }

    }
}
