using System.ComponentModel.DataAnnotations;

namespace Disaster_Response_System.Models.DTO
{
    public class AddRoundDTO
    {
        [Required]
        public string RoundName { get; set; }
        [Required]
        public bool RoundActive { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

    }
}

