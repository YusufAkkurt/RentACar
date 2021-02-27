using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Uploads
{
    public class UploadPathFounder
    {
        public static async Task<string> CarImageSave(IFormFile imageFile)
        {
            var getExtension = Path.GetExtension(imageFile.FileName).ToLower();
            var imageName = DateTime.Now.ToString("yymmssfff") + Guid.NewGuid() + getExtension;
            var imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + PathName.CarImages, imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
               await imageFile.CopyToAsync(fileStream);
            }

            string imagePathAndName = PathName.CarImages + "\\" + imageName;

            return imagePathAndName;
        }
    }
}