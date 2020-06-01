using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ImageUploadDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("uploadCarImage")]
        public async Task<string> OnPostUpload([FromForm] IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "/uploads/"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "/uploads");
                    }
                    var currentPath = _environment.WebRootPath + "/uploads/" + DateTime.Now.Ticks + "-" + file.FileName;
                    using (var stream = new FileStream(currentPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return file.FileName;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }
    }
}