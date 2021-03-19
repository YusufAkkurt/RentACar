using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Utilities.Uploaders
{
    public class UploadPathFounder
    {
        public static async Task<string> CarImageSave(IFormFile imageFile)
        {
            var getExtension = Path.GetExtension(imageFile.FileName).ToLower();
            var imageName = DateTime.Now.ToString("yymmssfff") + Guid.NewGuid() + getExtension;
            var imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + PathNames.AddCarImage, imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            string imagePathAndName = PathNames.CarImages + "\\" + imageName;

            return imagePathAndName;
        }
    }
}