using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AspFinalProje.FileExtensions
{
    public static class FileExtensions
    {
        public static bool IsImage(this HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" ||
                   file.ContentType == "image/jpeg" ||
                   file.ContentType == "image/png" ||
                   file.ContentType == "image/gif";
        }

        public static string SaveImage(this HttpPostedFileBase image, string subfolder)
        {
            string filename = subfolder + "/" + Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);

            string fullpath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), filename);

            image.SaveAs(fullpath);

            return filename;
        }

        public static bool DeleteImage(string folderPath,string filename)
        {
            string fullfilename = filename.Split('/')[1];
            string fullfilepath = Path.Combine(folderPath,fullfilename);

            if (File.Exists(fullfilepath))
            {
                File.Delete(fullfilepath);
                return true;
            }
            return false;
        }


    }
}