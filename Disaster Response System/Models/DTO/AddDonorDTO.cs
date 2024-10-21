using System.ComponentModel.DataAnnotations;

namespace Disaster_Response_System.Models.DTO
{
    public class AddDonorDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Organization { get; set; }

    }
}
