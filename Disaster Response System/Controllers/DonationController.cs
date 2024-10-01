using AutoMapper;
using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IDonationRepository donationRepository;
        public DonationController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IDonationRepository donationRepository)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.donationRepository = donationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donationDomain = await donationRepository.GetDonationsAsync();

            return Ok(mapper.Map<List<DonationDTO>>(donationDomain));
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var donationDomain = await donationRepository.GetDonationByIdAsync(id);

            if (donationDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DonationDTO>(donationDomain));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDonationDTO donationDTO)
        {
            var donor = await _dbContext.Donors.FindAsync(donationDTO.Donor);
            var round = await _dbContext.Rounds.FindAsync(donationDTO.Round);

            if (donor == null)
            {
                return NotFound();
            }

            var donationDomain = new Donation
            {
                DonationAmount = donationDTO.DonationAmount,
                Donor = donor,
                Round = round,
                DonationDate = DateTime.UtcNow,
            };

            await donationRepository.CreateDonationAsync(donationDomain);
            return CreatedAtAction(nameof(GetById), new { id = donationDomain.DonorID }, mapper.Map<DonationDTO>(donationDomain));

        }
    }
}

      