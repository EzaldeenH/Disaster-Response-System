using Disaster_Response_System.Data;

namespace Disaster_Response_System.Repositories
{
    public class SQLRequestRepository : IRequestRepository
    {

        private readonly DisasterResponseSystemDBContext _dbContext;

        public SQLRequestRepository(DisasterResponseSystemDBContext _dbContext)
        {
            this._dbContext = _dbContext;
            
        }

        public Task<Request?> CreateRequestAsync(Round round)
        {
            throw new NotImplementedException();
        }

        public Task<Request?> DeleteRequestAsync(Guid id, Round round)
        {
            throw new NotImplementedException();
        }

        public Task<Request?> GetRequestByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetRequestsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
