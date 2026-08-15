namespace Disaster_Response_System.Models.Domain
{
    public class RequestForm
    {
        public string Name { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int ElderlyCount { get; set; }
        public int DisabilityCount { get; set; }
        public bool Urgency { get; set; }
        public string HousingStatus { get; set; }
        public bool BasicNeedsAccess { get; set; }
        public bool MedicalNeeds { get; set; }
    }
}
