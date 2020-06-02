using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        public async Task<JObject> OnPostUpload([FromForm] IFormFile file)
        {
            if (file != null)
            {
                try
                {
                 var directory=   Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles/images/"));

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    var newfilename = DateTime.Now.Ticks + "-" + file.FileName;
                    var currentPath = directory + newfilename;
                    using (var stream = new FileStream(currentPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    dynamic result = new JObject();
                    result.url= string.Format("/StaticFiles/images/{0}", newfilename);
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}