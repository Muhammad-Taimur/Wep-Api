using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Models
{
    public class JoinClass 
    {
        public Restaurant Restaurant{get; set;}
        public string Name { get; set; }
        public Dhaba Dhaba { get; set; }
        public int Id{ get; set; }
        public string DhabaName { get; set; }

        
        // public Country Country{ get; set; }
        // public string Name1 { get; set; }


        //public Restaurant Create(Restaurant restaurant)
        //{
        //
        //    return new Restaurant()
        //    {
        //       
        //        Name = restaurant.Name,
        //        Country = restaurant.Country,
        //        CuisineType = restaurant.CuisineType
        //                       
        //    };
        //}
        //
        //public Dhaba Create (Dhaba dhaba)
        //{
        //    return new Dhaba()
        //    {
        //        Id = dhaba.Id,
        //        Name = dhaba.Name
        //
        //    };
        //}

    }
}
