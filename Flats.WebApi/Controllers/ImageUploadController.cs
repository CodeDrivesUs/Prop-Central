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

namespace Flats.WebApi.Controllers
{
    public class ImageUploadController : ApiController
    {
        // GET: ImageUpload
        [HttpPost]
        [EnableCors(origins: "", headers: "*", methods: "*")]
        public FineUploaderResult UploadFile(FineUpload upload, string folder)
        {
            // asp.net mvc will set extraParam1 and extraParam2 from the params object passed by Fine-Uploader
            string fileName = folder + Guid.NewGuid().ToString() + "." + GetFileExtention(upload.Filename);

            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + folder), fileName);
            try
            {
                upload.SaveAs(path);
            }
            catch (Exception ex)
            {
                return new FineUploaderResult(false, error: ex.Message);
            }

            // the anonymous object in the result below will be convert to json and set back to the browser
            return new FineUploaderResult(true, new { location = folder + "/" + fileName });
        }
        public string GetFileExtention(string FileName)
        {
            return FileName.Split('.').Last();
        }
    }
}
