using AutoMapper;
using Disaster_Response_System.CustomActionFilter;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDonationService _donationService;

        public DonationController(IMapper mapper, IDonationService donationService)
        {
            _mapper = mapper;
            _donationService = donationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donations = await _donationService.GetAllDonationsAsync();
            return Ok(donations);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var donation = await _donationService.GetDonationByIdAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return Ok(donation);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddDonationDTO donationDTO)
        {
                await _donationService.AddDonationAsync(donationDTO);
                return Ok();
        }
    }
}



