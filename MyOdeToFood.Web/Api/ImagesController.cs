using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using MyOdeToFood.Data.Models;
using MyOdeToFood.Data.Services;
using Image = MyOdeToFood.Data.Models.Image;

namespace MyOdeToFood.Web.Api
{
    public class ImagesController : ApiController
    {
        private MyOdeToFoodDbContext db = new MyOdeToFoodDbContext();

        // GET: api/Images
        public IQueryable<Image> GetImages()
        //public byte[] GetImages()
        
        {

           // using (var sb = new MyOdeToFoodDbContext())
           // {
           //
           //     var component = sb.Images;
           //     
           //     var context = HttpContext.Current;
           //     string filePath= HttpContext.Current.Server.MapPath("~/documents/"+ "a37aff2e-0b54-4fe5-b33a-e03177b882c9.jpg");
           //     context.Response.ContentType = "image/jpeg";
           //
           //     using (FileStream fileStream =  new FileStream(filePath, FileMode.Open))
           //     {
           //         using (var memoryStream = new MemoryStream())
           //         {
           //             fileStream.CopyTo(memoryStream);
           //             Bitmap image = new Bitmap(1, 1);
           //             image.Save(memoryStream, ImageFormat.Jpeg);
           //
           //             byte[] byteImage = memoryStream.ToArray();
           //             return byteImage;
           //         }
           //     }
           // }

               return db.Images.OrderByDescending(a=> a.Id);
        }

        // GET: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetImage(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImage(int id, Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.Id)
            {
                return BadRequest();
            }

            db.Entry(image).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
             
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Images
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> PostImage()
        {
            /*
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + Guid.NewGuid() + extension;
            image.Path = "~/Image/" + fileName;

            fileName = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image/"), fileName);

            image.ImageFile.SaveAs(fileName);*/


            //Agr Req multiform nhe hui tow Ye Error dega.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            
            //Give the Path to Image.
            var root = HttpContext.Current.Server.MapPath("~/documents");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {

                await Request.Content.ReadAsMultipartAsync(provider);

                foreach(MultipartFileData file in provider.FileData)
                {
                    //string email = provider.FormData.GetValues("image").SingleOrDefault();

                    //Replace / from file name 
                    string name= file.Headers.ContentDisposition.FileName.Replace("\"","");

                    //Create file name with Guid
                    string newfileName = Guid.NewGuid() + Path.GetExtension(name);

                    //Move file from current location to Target Folder
                    File.Move(file.LocalFileName, Path.Combine(root, newfileName));

                     var s = root + "\\" + newfileName;
                    //creating Image Blob as Byte to shown in Front End.
                    byte[]  blobByte ;
                    using (var fs = new FileStream(s, FileMode.Open, FileAccess.Read))
                    {
                        blobByte = new byte[fs.Length];
                        fs.Read(blobByte, 0, Convert.ToInt32(fs.Length));
                    
                    }
                    //Create new Image Instance
                    Image img = new Image();

                    // img.Name = name;
                    img.Path = root+ "\\" + newfileName;
                    img.ImageBlob = blobByte;
                    img.Name = newfileName;
                    
                    //Below lines form value input.["name"] is the form field in Angular
                    //img.Name = HttpContext.Current.Request["name"];
                    //img.Path = HttpContext.Current.Request["password"];

                    //saving in DB
                    MyOdeToFoodDbContext db = new MyOdeToFoodDbContext();
                    db.Images.Add(img);
                    db.SaveChanges();

                    //return Content(HttpStatusCode.Created,  img.Name+"\""+"Image Uploaded");
                }
            }

            catch (Exception ex)
            {
                throw new HttpException("Error-" + ex.Message);
            }

            return Content(HttpStatusCode.Created, "Image Uploaded in Server");

            //return Content(HttpStatusCode.Created, "Image Uploaded in Server");
            //return Created( Ok, new { });

           // return Content(HttpStatusCode.OK);

            /*
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];

            imageName = Path.GetFileNameWithoutExtension(postedFile.FileName).Replace(" ","-").Replace("/"," ");
            imageName = imageName + Guid.NewGuid() + Path.GetExtension(postedFile.FileName);

            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            MyOdeToFoodDbContext db = new MyOdeToFoodDbContext();
            
           db.Images.Add(img);
           db.SaveChanges();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Images.Add(img);
            db.SaveChanges();

            //return CreatedAtRoute(" ", new { id = img.Id }, img);
    */    
    }

        // DELETE: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult DeleteImage(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            db.Images.Remove(image);
            db.SaveChanges();

            return Ok(image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageExists(int id)
        {
            return db.Images.Count(e => e.Id == id) > 0;
        }
    }
}