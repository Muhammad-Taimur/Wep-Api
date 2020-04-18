using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Services
{
    public interface IDhabaData
    {
        IEnumerable<Dhaba> GetAll();
        Dhaba Get(int id);
        void Add(Dhaba dhaba);
        void Update(Dhaba dhaba);
     //   void Delete(int id);
    }
}
