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
    public class RoundService : IRoundService
    {
        private readonly IGenericRepository<Round> _roundRepository;
        private readonly IGenericRepository<Request> _requestRepository;
        private readonly IGenericRepository<Donation> _donationRepository;
        private readonly IMapper _mapper;

        public RoundService(IGenericRepository<Round> roundRepository, IGenericRepository<Request> requestRepository, IGenericRepository<Donation> donationRepository, IMapper mapper)
        {
            _roundRepository = roundRepository;
            _requestRepository = requestRepository;
            _donationRepository = donationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoundDTO>> GetAllRoundsAsync()
        {
            var rounds = await _roundRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoundDTO>>(rounds);
        }

        public async Task<RoundDTO> GetRoundByIdAsync(Guid id)
        {
            var round = await _roundRepository.GetByIdAsync(id);
            return _mapper.Map<RoundDTO>(round);
        }

        public async Task AddRoundAsync(AddRoundDTO roundDTO)
        {
            var round = _mapper.Map<Round>(roundDTO);
            await _roundRepository.CreateAsync(round);

            var donations = await _donationRepository.GetAllAsync();
            var nonActiveDonations = donations.Where(d => d.RoundID == null).ToList();

            foreach (var donation in nonActiveDonations)
            {
                donation.RoundID = round.RoundID;
                await _donationRepository.UpdateAsync(donation);
            }
        }

        public async Task UpdateRoundAsync(Guid id, bool roundActive)
        {
            var round = await _roundRepository.GetByIdAsync(id);

            if (round == null)
            {
                throw new KeyNotFoundException("Round not found");
            }

            round.RoundActive = roundActive;

            await _roundRepository.UpdateAsync(round);
            await CalculateFundsToDistribute(round.RoundID);
        }

        public async Task DeleteRoundAsync(Guid id)
        {
            await _roundRepository.DeleteAsync(id);
        }

        public async Task CalculateFundsToDistribute(Guid roundId)
        {
            var round = await _roundRepository.GetByIdAsync(roundId);

            if (round == null)
            {
                throw new KeyNotFoundException("Round not found");
            }

            // Step 1: Calculate the total amount of donations for the round
            decimal totalDonations = round.Donations.Sum(d => d.DonationAmount);

            // Step 2: Calculate the total evaluation score for all requests that are active
            decimal totalEvaluationScore = round.Requests
                .Where(r => r.RequestActive == true)
                .Sum(r => r.EvaluationScore);

            // Step 3: Distribute the funds proportionally based on the evaluation score of each active request
            foreach (var request in round.Requests)
            {
                if (request.RequestActive == true && totalEvaluationScore > 0)
                {
                    request.AllocatedFunds = Math.Round(request.EvaluationScore / totalEvaluationScore * totalDonations, 2);
                }
                else
                {
                    request.AllocatedFunds = 0;
                }
                await _requestRepository.UpdateAsync(request);
            }
        }
    }
}


