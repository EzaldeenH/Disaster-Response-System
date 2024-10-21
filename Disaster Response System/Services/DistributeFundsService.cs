using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public class DistributeFundsService
    {
        private readonly IGenericRepository<Round> _roundRepository;
        private readonly IGenericRepository<Request> _requestRepository;

        public DistributeFundsService(
            IGenericRepository<Round> roundRepository,
            IGenericRepository<Request> requestRepository)
        {
            _roundRepository = roundRepository;
            _requestRepository = requestRepository;
        }

        public async Task CalculateFundsToDistribute(Round round)
        {

            // Step 1: Calculate the total amount of donations for the round
            decimal totalDonations = round.Donations.Sum(d => d.DonationAmount);

            // Step 2: Calculate the total evaluation score for all requests that are not active
            decimal totalEvaluationScore = round.Requests
                .Where(r => r.RequestActive)
                .Sum(r => r.EvaluationScore);

            // Step 3: Distribute the funds proportionally based on the evaluation score of each active and incomplete request
            foreach (var request in round.Requests)
            {
                if (request.RequestActive && totalEvaluationScore > 0)
                {
                    request.AllocatedFunds = (request.EvaluationScore / totalEvaluationScore) * totalDonations;
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
