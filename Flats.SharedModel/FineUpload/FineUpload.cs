using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Flats.SharedModel.FineUpload
{

    public class FineUpload
    {
        public Stream InputStream { get; set; }
        public HttpPostedFile file { get; set; }
        public string folder { get; set; }
        public string FileName { get; set; }
        public FineUpload(HttpPostedFile file, string folder)
        {
            this.file = file;
            this.folder = folder;
            FileName = GetFileName();
            InputStream = ConvertHttpFilePostedToStream();
        }

        public void SaveAs(string destination, bool overwrite = false, bool autoCreateDirectory = true)
        {
            if (autoCreateDirectory)
            {
                var directory = new FileInfo(destination).Directory;
                if (directory != null) directory.Create();
            }

            using (var file = new FileStream(destination, overwrite ? FileMode.Create : FileMode.CreateNew))
                InputStream.CopyTo(file);
        }
        public Stream ConvertHttpFilePostedToStream()
        {
            return file.InputStream;
        }
        public string GetFileName()
        {
           return folder + Guid.NewGuid().ToString() + "." + GetFileExtention(Path.GetFileName(file.FileName));
        }
        public string GetFileExtention(string FileName)
        {
            return FileName.Split('.').Last();
        }

    }
}
