using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotTheFire.Api.Models;

namespace SpotTheFire.Api.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private static readonly List<ImageModel> Images = new List<ImageModel>();

        private readonly ILogger<ImagesController> _logger;

        public ImagesController(ILogger<ImagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImageModel>> Get()
        {
            _logger.LogInformation("Get all images request...");

            if (Images.Count > 0)
            {
                return Images;
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<ImageModel> Get(string id)
        {
            _logger.LogInformation($"Get image by id {id} request...");

            var image = Images.FirstOrDefault(x => x.Id == id);

            if (image != null)
            {
                return image;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddImageModel model)
        {
             _logger.LogInformation("Post image request...");

            string id = Guid.NewGuid().ToString();

            Images.Add(new ImageModel
            {
                Id = id,
                Description = model.Description,
                ImageBase64 = model.ImageBase64,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            });

            return CreatedAtAction(nameof(Get), new { id = id }, new { id = id });
        }
    }
}
