using Disaster_Response_System.Models.Domain;
using System.Text.Json.Serialization;

public class Donation
{
    public Guid DonationID { get; set; }              
    public Guid DonorID { get; set; }                 
    public Guid? RoundID { get; set; }                 
    public decimal DonationAmount { get; set; }      
    public DateTime DonationDate { get; set; }

    // Navigation properties
    public Donor Donor { get; set; }
    public Round? Round { get; set; }
}
