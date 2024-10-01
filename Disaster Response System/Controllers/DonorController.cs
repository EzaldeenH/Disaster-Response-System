using AutoMapper;
using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {

        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IDonorRepository donorRepository;
        public DonorController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IDonorRepository donorRepository)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.donorRepository = donorRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donorDomain = await donorRepository.GetDonorsAsync();

            return Ok(mapper.Map<List<DonorDTO>>(donorDomain));
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var donorDomain = await donorRepository.GetDonorByIdAsync(id);

            if (donorDomain == null )
            {
                return NotFound();
            }

            return Ok(mapper.Map<DonorDTO>(donorDomain));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDonorDTO donorDTO)
        {
            var donorDomain = mapper.Map<Donor>(donorDTO);
            await donorRepository.CreateDonorAsync(donorDomain);
            return CreatedAtAction(nameof(GetById), new { id = donorDomain.DonorID }, mapper.Map<DonorDTO>(donorDomain));

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddDonorDTO donorDTO)
        {
            var donorDomain = mapper.Map<Donor>(donorDTO);
            await donorRepository.UpdateDonorAsync(id, donorDomain);

            if (donorDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DonorDTO>(donorDomain));
        }
    }
}
