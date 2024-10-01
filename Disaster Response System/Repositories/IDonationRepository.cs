namespace Disaster_Response_System.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetDonationsAsync();
        Task<Donation?> GetDonationByIdAsync(Guid id);
        Task<Donation?> CreateDonationAsync(Donation donation);

    }
}
