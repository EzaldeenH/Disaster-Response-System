using System.Text.Json.Serialization;

namespace Disaster_Response_System.Models.Domain
{
    public class Donor
    {
        public Guid DonorID { get; set; }
        public string Name { get; set; }
        public string? Organization { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
