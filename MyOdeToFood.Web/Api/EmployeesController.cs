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
    public class EmployeesController : ApiController
    {
        private readonly IEmployee db;

        public EmployeesController(IEmployee db)
        {
            this.db = db;
        }

        public  IEnumerable<Employee>Get()
        {
            return db.GetAll();
        }

        MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext();

        [HttpGet]
        public Employee Get(int id)
        {
                //using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
                return sd.Employees.FirstOrDefault(r => r.Id == id);            

        }

        //public void Post([FromBody] Employee employee)
        public Employee Post(Employee employee)
        {
            using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            {
                sd.Employees.Add(employee);
                sd.SaveChanges();

                //return sd.Employees.Find(employee);
                return employee;
            }

        }

        public void Delete(int id)
        {

            using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            {
                sd.Employees.Remove(sd.Employees.FirstOrDefault(r => r.Id == id));
                sd.SaveChanges();



            }
        }

        public Employee  Put(int id,  Employee employee)
        {
            using (MyOdeToFoodDbContext sd = new MyOdeToFoodDbContext())
            {
               
                var entity = sd.Employees.FirstOrDefault(r => r.Id == id);
                entity.Name = employee.Name;
                entity.Age = employee.Age;
                
                sd.SaveChanges();

                return employee;
            }

        }

    }

}

