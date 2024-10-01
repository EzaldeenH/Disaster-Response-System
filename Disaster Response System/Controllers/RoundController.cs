using AutoMapper;
using Disaster_Response_System.Data;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IRoundRepository roundRepository;
        public RoundController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IRoundRepository roundRepository)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.roundRepository = roundRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roundDomain = await roundRepository.GetRoundsAsync();

            return Ok(mapper.Map<List<RoundDTO>>(roundDomain));
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var roundDomain = await roundRepository.GetRoundByIdAsync(id);

            if (roundDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RoundDTO>(roundDomain));

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRoundDTO roundDTO)
        {
            var roundDomain = mapper.Map<Round>(roundDTO);
            await roundRepository.CreateRoundAsync(roundDomain);
            return CreatedAtAction(nameof(GetById), new { id = roundDomain.RoundID }, mapper.Map<RoundDTO>(roundDomain));

        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RoundStatusDTO roundDTO)
        {
            var roundDomain = new Round
            {
                RoundActive = roundDTO.RoundActive,
            };

            var updatedRound = await roundRepository.UpdateRoundAsync(id, roundDomain);

            if (updatedRound == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RoundDTO>(updatedRound));
        }

    }
}
