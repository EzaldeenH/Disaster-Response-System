using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Repositories
{
    public class SQLDonationRepository : IDonationRepository
    {
        private readonly DisasterResponseSystemDBContext _dbContext;

        public SQLDonationRepository(DisasterResponseSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Donation>> GetDonationsAsync()
        {
            return await _dbContext.Donations
                .Include(d => d.Donor)
                .Include(d => d.Round)
                .ToListAsync();
        }

        public async Task<Donation?> GetDonationByIdAsync(Guid id)
        {
            return await _dbContext.Donations
                .Include(d => d.Donor)
                .Include(d => d.Round)
                .FirstOrDefaultAsync(d => d.DonationID == id);
        }

        public async Task<Donation?> CreateDonationAsync(Donation donation)
        {
            _dbContext.Donations.Add(donation);
            await _dbContext.SaveChangesAsync();
            return donation;
        }
    }
}
