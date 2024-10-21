public class Request
{
    public Guid RequestID { get; set; }               
    public string ApplicantName { get; set; }           
    public bool RequestActive { get; set; }        
    public Guid RoundID { get; set; }                 
    public DateTime SubmissionDate { get; set; }     
    public decimal EvaluationScore { get; set; }     
    public decimal AllocatedFunds { get; set; } 

    // Navigation property
    public virtual Round Round { get; set; }
}
