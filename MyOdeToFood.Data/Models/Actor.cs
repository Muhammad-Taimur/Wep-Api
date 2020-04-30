using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOdeToFood.Data.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string  ActorName{ get; set; }

        [ForeignKey ("Movie")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
