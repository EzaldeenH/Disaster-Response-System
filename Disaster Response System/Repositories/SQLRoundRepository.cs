using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Repositories
{
    public class SQLRoundRepository : IRoundRepository
    {
        private readonly DisasterResponseSystemDBContext _dbContext;

        public SQLRoundRepository(DisasterResponseSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Round>> GetRoundsAsync()
        {
            return await _dbContext.Rounds
                .Include(r => r.Donations)
                .ToListAsync();
        }

        public async Task<Round?> GetRoundByIdAsync(Guid id)
        {
            return await _dbContext.Rounds
                .Include(r => r.Donations)
                .FirstOrDefaultAsync(r => r.RoundID == id);
        }

        public async Task<Round?> CreateRoundAsync(Round round)
        {
            _dbContext.Rounds.Add(round);
            await _dbContext.SaveChangesAsync();
            return round;
        }

        public async Task<Round?> UpdateRoundAsync(Guid id, Round round)
        {
            var existingRound = await _dbContext.Rounds.FindAsync(id);
            if (existingRound == null)
            {
                return null;
            }

            existingRound.RoundActive = round.RoundActive;
            await _dbContext.SaveChangesAsync();
            return existingRound;
        }
    }
}
