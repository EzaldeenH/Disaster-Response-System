using AutoMapper;
using Disaster_Response_System.CustomActionFilter;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoundService _roundService;

        public RoundController(IMapper mapper, IRoundService roundService)
        {
            _mapper = mapper;
            _roundService = roundService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rounds = await _roundService.GetAllRoundsAsync();
            return Ok(rounds);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var round = await _roundService.GetRoundByIdAsync(id);
            if (round == null)
            {
                return NotFound();
            }
            return Ok(round);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRoundDTO roundDTO)
        {
            var activeRound = (await _roundService.GetAllRoundsAsync()).FirstOrDefault(x => x.RoundActive == true);

            if (activeRound != null)
            {
                return BadRequest("Active round exists, consider closing it before making a new one.");
            }

            await _roundService.AddRoundAsync(roundDTO);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] bool roundActive)
        {
            try
            {
                await _roundService.UpdateRoundAsync(id, roundActive);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{roundId}/distribute-funds")]
        public async Task<IActionResult> DistributeFunds(Guid roundId)
        {
            try
            {
                await _roundService.CalculateFundsToDistribute(roundId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

