using AutoMapper;
using Disaster_Response_System.CustomActionFilter;
using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Disaster_Response_System.Services; // Add this line to include the services namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Round> roundRepository;
        private readonly IGenericRepository<Donation> donationRepository;
        private readonly DistributeFundsService distributeFundsService; // Add this line to include the service

        public RoundController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IGenericRepository<Round> roundRepository, IGenericRepository<Donation> donationRepository, DistributeFundsService distributeFundsService)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.roundRepository = roundRepository;
            this.donationRepository = donationRepository;
            this.distributeFundsService = distributeFundsService; // Initialize the service
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rounds = await roundRepository.GetAllAsync();
            return Ok(mapper.Map<List<RoundDTO>>(rounds));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var round = await roundRepository.GetByIdAsync(id);
            if (round == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RoundDTO>(round));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRoundDTO roundDTO)
        {
            var round = mapper.Map<Round>(roundDTO);
            var activeRound = await _dbContext.Rounds.FirstOrDefaultAsync(x => x.RoundActive == true);

            if (activeRound != null)
            {
                return BadRequest("Active round exists, consider closing it before making a new one.");
            }

            await roundRepository.CreateAsync(round);

            var donations = await donationRepository.GetAllAsync();
            var nonActiveDonations = donations.Where(d => d.RoundID == null).ToList();

            foreach (var donation in nonActiveDonations)
            {
                donation.RoundID = round.RoundID;
                await donationRepository.UpdateAsync(donation);
            }

            return CreatedAtAction(nameof(GetById), new { id = round.RoundID }, mapper.Map<RoundDTO>(round));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            var round = await roundRepository.GetByIdAsync(id);

            if (round == null)
            {
                return NotFound();
            }

            round.RoundActive = false;

            await roundRepository.UpdateAsync(round);

            // Use the DistributeFundsService to calculate and distribute funds
            await distributeFundsService.CalculateFundsToDistribute(round);

            return Ok(mapper.Map<RoundDTO>(round));
        }


        [HttpPost("{roundId}/distribute-funds")]
        public async Task<IActionResult> DistributeFundsTest(Guid roundId)
        {
            try
            {
                var round = await roundRepository.GetByIdAsync(roundId);

                if (round == null)
                {
                    return NotFound();
                }

                await distributeFundsService.CalculateFundsToDistribute(round);
                return Ok(round);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}