using Disaster_Response_System.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Response_System.Models.DTO
{
    public class AddDonationDTO
    {
        [Required]
        [Range(1, double.MaxValue)]
        public decimal DonationAmount { get; set; }
        [Required]
        public Guid Donor { get; set; }
    }
}
