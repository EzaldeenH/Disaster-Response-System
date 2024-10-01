using Disaster_Response_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Repositories
{
    public class SQLRoundRepository : IRoundRepository
    {
        private readonly DisasterResponseSystemDBContext _dBContext;

        public SQLRoundRepository(DisasterResponseSystemDBContext _dBContext)
        {
            this._dBContext = _dBContext;
        }

        public async Task<Round?> CreateRoundAsync(Round round)
        {
            await _dBContext.Rounds.AddAsync(round);
            await _dBContext.SaveChangesAsync();

            return round;
        }

        public async Task<Round?> GetRoundByIdAsync(Guid id)
        {
            return await _dBContext.Rounds.FirstOrDefaultAsync(x => x.RoundID == id);
        }

        public async Task<List<Round>> GetRoundsAsync()
        {
            return await _dBContext.Rounds.ToListAsync();
        }

        public async Task<Round?> UpdateRoundAsync(Guid id, Round round)
        {
            var existingRound = await _dBContext.Rounds.FirstOrDefaultAsync(x => x.RoundID == id);

            if (existingRound != null)
            {
                existingRound.RoundActive = round.RoundActive;

                await _dBContext.SaveChangesAsync();
                return round;
            }

            return null;
        }
    }
}
