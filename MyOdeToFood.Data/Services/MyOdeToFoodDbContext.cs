using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Services
{
    public class MyOdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants{ get; set; }
        public DbSet<Dhaba> Dhabas{ get; set; }

        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Image> Images { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>().HasMany(a => a.Actor);
        //}
    }
}
