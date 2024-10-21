public class Round
{
    public Guid RoundID { get; set; }               
    public string RoundName { get; set; }            
    public bool RoundActive { get; set; }         
    public DateTime StartDate { get; set; }                  

    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Donation> Donations { get; set; }
}
