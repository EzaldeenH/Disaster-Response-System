using AutoMapper;
using Disaster_Response_System.CustomActionFilter;
using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Donation> donationRepository;

        public DonationController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IGenericRepository<Donation> donationRepository)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.donationRepository = donationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donations = await donationRepository.GetAllAsync();
            return Ok(mapper.Map<List<DonationDTO>>(donations));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var donation = await donationRepository.GetByIdAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DonationDTO>(donation));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddDonationDTO donationDTO)
        {
            var donor = await _dbContext.Donors.FindAsync(donationDTO.Donor);
            var activeRound = await _dbContext.Rounds.FirstOrDefaultAsync(r => r.RoundActive);


            if (donor == null)
            {
                return NotFound();
            }

            var donationDomain = new Donation
            {
                DonationAmount = donationDTO.DonationAmount,
                Donor = donor,
                Round = activeRound,
                DonationDate = DateTime.UtcNow,
            };

            await donationRepository.CreateAsync(donationDomain);
            return CreatedAtAction(nameof(GetById), new { id = donationDomain.DonationID }, mapper.Map<DonationDTO>(donationDomain));
        }
    }
}
 