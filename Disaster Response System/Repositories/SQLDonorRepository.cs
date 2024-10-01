using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Repositories
{
    public class SQLDonorRepository : IDonorRepository
    {

        private readonly DisasterResponseSystemDBContext _dbContext;
        public SQLDonorRepository(DisasterResponseSystemDBContext _dBContext) 
        { 
            this._dbContext = _dBContext;
        }
        public async Task<Donor?> CreateDonorAsync(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();

            return donor;
        }

        public async Task<Donor?> GetDonorByIdAsync(Guid id)
        {
            return await _dbContext.Donors.FirstOrDefaultAsync(x => x.DonorID == id);
        }

        public async Task<List<Donor>> GetDonorsAsync()
        {
            return await _dbContext.Donors.ToListAsync();
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
