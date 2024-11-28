using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestDTO>> GetAllRequestsAsync();
        Task<RequestDTO> GetRequestByIdAsync(Guid id);
        Task AddRequestAsync(RequestFormDTO requestDTO);
        Task DeleteRequestAsync(Guid id);
        int CalculateScore(RequestForm request);
    }
}
