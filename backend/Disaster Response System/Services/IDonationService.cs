using Disaster_Response_System.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public interface IDonationService
    {
        Task<IEnumerable<DonationDTO>> GetAllDonationsAsync();
        Task<DonationDTO> GetDonationByIdAsync(Guid id);
        Task AddDonationAsync(AddDonationDTO donationDTO);
    }
}



