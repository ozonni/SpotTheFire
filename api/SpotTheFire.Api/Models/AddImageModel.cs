using System.ComponentModel.DataAnnotations;

namespace SpotTheFire.Api.Models
{
    public class AddImageModel
    {
        public string Description { get; set; }

        [Required]
        public string ImageBase64 { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}