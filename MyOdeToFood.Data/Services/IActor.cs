using MyOdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Services
{
    public interface IActor
    {

        IEnumerable <Actor> GetAll();
        Actor Get(int id);
        void Add(Actor actor);
        void Update(Actor actor);
        //   void Delete(int id);
    }
}
