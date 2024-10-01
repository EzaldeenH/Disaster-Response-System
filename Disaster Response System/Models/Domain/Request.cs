public class Request
{
    public Guid RequestID { get; set; }               
    public string ApplicantName { get; set; }        
    public string ApplicantContact { get; set; }     
    public string RequestStatus { get; set; }        
    public Guid RoundID { get; set; }                 
    public DateTime SubmissionDate { get; set; }     
    public decimal EvaluationScore { get; set; }     

    // Navigation property
    public Round Round { get; set; }
}
