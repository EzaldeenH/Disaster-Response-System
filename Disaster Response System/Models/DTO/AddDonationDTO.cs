using Disaster_Response_System.Models.Domain;

namespace Disaster_Response_System.Models.DTO
{
    public class AddDonationDTO
    {
        public decimal DonationAmount { get; set; }

        public Guid Donor { get; set; }
    }
}
