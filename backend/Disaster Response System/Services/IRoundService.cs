using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public interface IRoundService
    {
        Task<IEnumerable<RoundDTO>> GetAllRoundsAsync();
        Task<RoundDTO> GetRoundByIdAsync(Guid id);
        Task AddRoundAsync(AddRoundDTO roundDTO);
        Task UpdateRoundAsync(Guid id, bool roundActive);
        Task DeleteRoundAsync(Guid id);
        Task CalculateFundsToDistribute(Guid roundId);
    }
}
