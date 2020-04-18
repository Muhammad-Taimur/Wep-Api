using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data
{
    public class Restaurant
    {
        
        public int Id{ get; set; }


        public Cuisine CuisineType{ get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string  City{ get; set; }


        [Required]
        public Country Country { get; set; }
        
                          
    }
}
