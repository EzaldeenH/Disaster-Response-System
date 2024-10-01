using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Repositories
{
    public class SQLDonorRepository : IDonorRepository
    {
        private readonly DisasterResponseSystemDBContext _dbContext;

        public SQLDonorRepository(DisasterResponseSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Donor>> GetDonorsAsync()
        {
            return await _dbContext.Donors
                .Include(d => d.Donations)
                .ToListAsync();
        }

        public async Task<Donor?> GetDonorByIdAsync(Guid id)
        {
            return await _dbContext.Donors
                .Include(d => d.Donations)
                .FirstOrDefaultAsync(d => d.DonorID == id);
        }

        public async Task<Donor?> CreateDonorAsync(Donor donor)
        {
            _dbContext.Donors.Add(donor);
            await _dbContext.SaveChangesAsync();
            return donor;
        }

        public async Task<Donor?> UpdateDonorAsync(Guid id, Donor donor)
        {
            var existingDonor = await _dbContext.Donors.FirstOrDefaultAsync(x => x.DonorID == id);

            if (existingDonor != null)
            {
                existingDonor.Name = donor.Name;

                existingDonor.Organization = donor.Organization;

                await _dbContext.SaveChangesAsync();
                return donor;
            }

            return null;
        }
    }
}
