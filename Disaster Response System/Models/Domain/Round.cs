public class Round
{
    public Guid RoundID { get; set; }               
    public string RoundName { get; set; }            
    public bool RoundActive { get; set; }         
    public DateTime StartDate { get; set; }                  

    public ICollection<Request> Requests { get; set; }
    public ICollection<Donation> Donations { get; set; }
}
