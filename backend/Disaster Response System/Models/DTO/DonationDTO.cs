using Disaster_Response_System.Models.Domain;

namespace Disaster_Response_System.Models.DTO
{
    public class DonationDTO
    {
        public Guid DonationID { get; set; }
        public decimal DonationAmount { get; set; }
        public DateTime DonationDate { get; set; }
        public DonorDTO Donor { get; set; }
        public RoundDTO? Round { get; set; }
    }
}
