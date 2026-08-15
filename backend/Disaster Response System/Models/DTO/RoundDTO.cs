namespace Disaster_Response_System.Models.DTO
{
    public class RoundDTO
    {
    public Guid RoundID { get; set; }
    public string RoundName { get; set; }
    public bool RoundActive { get; set; }
    public DateTime StartDate { get; set; }
    public ICollection<RequestDTO?> Requests { get; set; }
    public ICollection<DonationDTO?> Donations { get; set; }
}
}
