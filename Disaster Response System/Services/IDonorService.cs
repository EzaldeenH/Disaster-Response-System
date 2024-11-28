using Disaster_Response_System.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public interface IDonorService
    {
        Task<IEnumerable<DonorDTO>> GetAllDonorsAsync();
        Task<DonorDTO> GetDonorByIdAsync(Guid id);
        Task AddDonorAsync(AddDonorDTO donorDTO);
        Task UpdateDonorAsync(Guid id, AddDonorDTO donorDTO);
        Task DeleteDonorAsync(Guid id);
    }
}
