namespace Disaster_Response_System.Repositories
{
    public interface IRequestRepository
    {
        Task<Request?> CreateRequestAsync(Round round);
        Task<Request?> GetRequestByIdAsync(Guid id);
        Task<List<Request>> GetRequestsAsync();
        Task<Request?> DeleteRequestAsync(Guid id, Round round);
    }
}
