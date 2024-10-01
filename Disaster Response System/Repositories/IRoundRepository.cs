namespace Disaster_Response_System.Repositories
{
    public interface IRoundRepository
    {
        Task<Round?> CreateRoundAsync(Round round);
        Task<Round?> GetRoundByIdAsync(Guid id);
        Task<List<Round>> GetRoundsAsync();
        Task<Round?> UpdateRoundAsync(Guid id, Round round);
    }
}
