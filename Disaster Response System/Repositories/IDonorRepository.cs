using Disaster_Response_System.Models.Domain;

namespace Disaster_Response_System.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetDonorsAsync();
        Task<Donor?> GetDonorByIdAsync(Guid id);
        Task<Donor?> CreateDonorAsync(Donor donor);
        Task<Donor?> UpdateDonorAsync(Guid id,Donor donor);


    }
}
