namespace Disaster_Response_System.Models.DTO
{
    public class DonorDTO
    {
        public Guid DonorID { get; set; }
        public string Name { get; set; }
        public string? Organization { get; set; }
        public ICollection<DonationDTO> Donations { get; set; }
    }
}
