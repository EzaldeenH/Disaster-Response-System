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
    public class DonorController : ControllerBase
    {
        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Donor> donorRepository;

        public DonorController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IGenericRepository<Donor> donorRepository)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.donorRepository = donorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await donorRepository.GetAllAsync();
            return Ok(mapper.Map<List<DonorDTO>>(donors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var donor = await donorRepository.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DonorDTO>(donor));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddDonorDTO donorDTO)
        {
            var donor = mapper.Map<Donor>(donorDTO);
            await donorRepository.CreateAsync(donor);
            return CreatedAtAction(nameof(GetById), new { id = donor.DonorID }, mapper.Map<DonorDTO>(donor));
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddDonorDTO donorDTO)
        {
            var donor = await donorRepository.GetByIdAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            donor.Name = donorDTO.Name;
            donor.Organization = donorDTO.Organization;

            await donorRepository.UpdateAsync(donor);
            return Ok();
        }
    }
}
