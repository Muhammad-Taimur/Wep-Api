using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Services
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
         Employee Get(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        //   void Delete(int id);
    }
}
