using AutoMapper;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public class RequestService : IRequestService
    {
        private readonly IGenericRepository<Request> _requestRepository;
        private readonly IGenericRepository<Round> _roundRepository;
        private readonly IMapper _mapper;

        public RequestService(IGenericRepository<Request> requestRepository, IGenericRepository<Round> roundRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _roundRepository = roundRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RequestDTO>> GetAllRequestsAsync()
        {
            var requests = await _requestRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RequestDTO>>(requests);
        }

        public async Task<RequestDTO> GetRequestByIdAsync(Guid id)
        {
            var request = await _requestRepository.GetByIdAsync(id);
            return _mapper.Map<RequestDTO>(request);
        }

        public async Task AddRequestAsync(RequestFormDTO requestDTO)
        {
            var activeRound = await _roundRepository.GetAllAsync();
            var round = activeRound.FirstOrDefault(r => r.RoundActive);

            if (round == null)
            {
                throw new UnauthorizedAccessException("No active round found");
            }

            int evaluation = CalculateScore(_mapper.Map<RequestForm>(requestDTO));

            var request = new Request
            {
                ApplicantName = requestDTO.Name,
                RequestActive = true,
                Round = round,
                SubmissionDate = DateTime.UtcNow,
                EvaluationScore = evaluation,
            };

            await _requestRepository.CreateAsync(request);
        }

        public async Task DeleteRequestAsync(Guid id)
        {
            await _requestRepository.DeleteAsync(id);
        }

        public int CalculateScore(RequestForm request)
        {
            int score = 0;

            // urgency and time constraints score
            if (request.Urgency)
            {
                score += 30;
            }

            // Need score
            // 1. Household Composition
            score += request.AdultCount * 10; // Each adult adds 10 points
            score += request.ChildCount * 15; // Each child adds 15 points
            score += request.ElderlyCount * 20; // Each elderly person adds 20 points
            score += request.DisabilityCount * 25; // Each disabled person adds 25 points

            // 2. Housing Status
            switch (request.HousingStatus)
            {
                case "homeless":
                    score += 50; // Homeless gets the highest priority
                    break;
                case "uninhabitable":
                    score += 40; // Uninhabitable house
                    break;
                case "damaged":
                    score += 30; // Damaged but inhabitable house
                    break;
                case "intact":
                    score += 10; // House is intact but financial difficulties
                    break;
            }

            // 3. Access to Basic Needs
            if (!request.BasicNeedsAccess)
            {
                score += 20; // Add points if basic needs are not available
            }

            // 4. Medical Needs
            if (request.MedicalNeeds)
            {
                score += 30; // Add points if there are urgent medical needs
            }

            return score;
        }
    }
}
