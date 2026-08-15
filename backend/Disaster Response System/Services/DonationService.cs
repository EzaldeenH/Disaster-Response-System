using AutoMapper;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public class DonationService : IDonationService
    {
        private readonly IGenericRepository<Donation> _donationRepository;
        private readonly IGenericRepository<Donor> _donorRepository;
        private readonly IGenericRepository<Round> _roundRepository;
        private readonly IMapper _mapper;

        public DonationService(IGenericRepository<Donation> donationRepository, IGenericRepository<Donor> donorRepository, IGenericRepository<Round> roundRepository, IMapper mapper)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _roundRepository = roundRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DonationDTO>> GetAllDonationsAsync()
        {
            var donations = await _donationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DonationDTO>>(donations);
        }

        public async Task<DonationDTO> GetDonationByIdAsync(Guid id)
        {
            var donation = await _donationRepository.GetByIdAsync(id);
            return _mapper.Map<DonationDTO>(donation);
        }

        public async Task AddDonationAsync(AddDonationDTO donationDTO)
        {
            var donor = await _donorRepository.GetByIdAsync(donationDTO.Donor);
            var activeRound = (await _roundRepository.GetAllAsync()).FirstOrDefault(r => r.RoundActive);

            if (donor == null)
            {
                throw new KeyNotFoundException("Donor not found");
            }

            var donation = new Donation
            {
                DonationAmount = donationDTO.DonationAmount,
                Donor = donor,
                Round = activeRound,
                DonationDate = DateTime.UtcNow,
            };

            await _donationRepository.CreateAsync(donation);
        }
    }
}



