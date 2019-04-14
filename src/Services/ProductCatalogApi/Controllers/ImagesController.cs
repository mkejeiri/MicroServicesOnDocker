using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public ImagesController(IHostingEnvironment environment )
        {
            _environment = environment;
        }
        [Route("{id}")]
        public IActionResult GetImage(int id)
        {
            var wwwroot = _environment.WebRootPath;
            var imageFullPath = Path.Combine($"{wwwroot}/Images/", $"shoes-{id}.png");
            var buffer = System.IO.File.ReadAllBytes(imageFullPath);
            return File(buffer,"Image/png");
        }
    } 
}