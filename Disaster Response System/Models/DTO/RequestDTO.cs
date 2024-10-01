namespace Disaster_Response_System.Models.DTO
{
    public class RequestDTO
    {
        public Guid RequestID { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantContact { get; set; }
        public string RequestStatus { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal EvaluationScore { get; set; }

        // Navigation property
        public RoundDTO? Round { get; set; }
    }

}

