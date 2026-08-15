using System.ComponentModel.DataAnnotations;

namespace Disaster_Response_System.Models.DTO
{
    public class RequestFormDTO
    {
        [Required]
        [MinLength(3, ErrorMessage ="Name can't be less than 3 charecters")]
        public string Name { get; set; }
        [Required]
        [Range(1,10, ErrorMessage ="Adult number must be between 1 and 10")]
        public int AdultCount { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Child number must be between 0 and 10")]
        public int ChildCount { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Elderly number must be between 0 and 10")]
        public int ElderlyCount { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Disability number must be between 0 and 10")]
        public int DisabilityCount { get; set; }
        [Required]
        public bool Urgency { get; set; }
        [Required]
        public string HousingStatus { get; set; }
        [Required]
        public bool BasicNeedsAccess { get; set; }
        [Required]
        public bool MedicalNeeds { get; set; }
    }
}
