namespace Disaster_Response_System.Models.DTO
{
    public class AddRequestDTO
    {
        public string ApplicantName { get; set; }
        public string ApplicantContact { get; set; }
        public string RequestStatus { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal EvaluationScore { get; set; }
        public Guid Round { get; set; }
    }
}
