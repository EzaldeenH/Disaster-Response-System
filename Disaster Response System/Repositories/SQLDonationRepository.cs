
using Disaster_Response_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Repositories
{
    public class SQLDonationRepository : IDonationRepository    
    {

        private readonly DisasterResponseSystemDBContext _dBContext;

        public SQLDonationRepository( DisasterResponseSystemDBContext _dBContext)
        {
            this._dBContext = _dBContext;
        }


        public async Task<Donation?> CreateDonationAsync(Donation donation)
        {
            await _dBContext.Donations.AddAsync(donation);
            await _dBContext.SaveChangesAsync();

            return donation;
        }

        public async Task<Donation?> GetDonationByIdAsync(Guid id)
        {
            return await _dBContext.Donations.FirstOrDefaultAsync(x => x.DonationID == id);
        }

        public async Task<List<Donation>> GetDonationsAsync()
        {
            return await _dBContext.Donations.ToListAsync();
        }
    }
}
