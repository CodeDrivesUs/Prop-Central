using Flats.SharedModel.FineUpload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Flats.Api.Controllers
{
    public class ImageUploadController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage UploadFile( string folder)
        {
            string fileName="";
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                 HttpContext.Current.Request.Files[0] : null;            
           
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    var upload = new FineUpload(file, folder);
                    fileName = upload.FileName;
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + folder), upload.FileName);
                    upload.SaveAs(path);
                  
                }
                catch (Exception ex)
                {
                    var result= new FineUploaderResult(false, error: ex.Message);
                    return result.SendResponse();
                }
            }


            var results = new FineUploaderResult(true, new { location = folder + "/" + fileName });
            return results.SendResponse() ;
        }
      
    }
}
