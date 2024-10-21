namespace Disaster_Response_System.Models.DTO
{
    public class RequestDTO
    {
        public Guid RequestID { get; set; }
        public string ApplicantName { get; set; }
        public bool RequestActive { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal EvaluationScore { get; set; }
        public decimal AllocatedFunds { get; set; }

        // Navigation property
        public RoundDTO? Round { get; set; }
    }

}

