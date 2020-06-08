using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyOdeToFood.Data.Models
{
    public class Image
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Path{ get; set; }
        

        public byte[] ImageBlob{ get; set; }

        //[NotMapped]
        //public HttpPostedFileBase ImageFile { get; set; }

    }
}
