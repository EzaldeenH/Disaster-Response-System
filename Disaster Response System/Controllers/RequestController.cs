using AutoMapper;
using Disaster_Response_System.CustomActionFilter;
using Disaster_Response_System.Data;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly DisasterResponseSystemDBContext _dbContext;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Request> requestRepository;
        private readonly EvaluationService evaluationService;

        public RequestController(DisasterResponseSystemDBContext _dbContext, IMapper mapper, IGenericRepository<Request> requestRepository, EvaluationService evaluationService)
        {
            this._dbContext = _dbContext;
            this.mapper = mapper;
            this.requestRepository = requestRepository;
            this.evaluationService = evaluationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requestDomain = await requestRepository.GetAllAsync();
            return Ok(mapper.Map<List<RequestDTO>>(requestDomain));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var requestDomain = await requestRepository.GetByIdAsync(id);

            if (requestDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RequestDTO>(requestDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] RequestFormDTO requestDTO)
        {
            var activeRound = await _dbContext.Rounds.FirstOrDefaultAsync(r => r.RoundActive);

            if (activeRound == null)
            {
                return Unauthorized();
            }

            int evaluation = evaluationService.CalculateScore(mapper.Map<RequestForm>(requestDTO));

            var requestDomain = new Request
            {
                ApplicantName = requestDTO.Name,
                RequestActive = true,
                Round = activeRound,
                SubmissionDate = DateTime.UtcNow,
                EvaluationScore = evaluation,

            };

            await requestRepository.CreateAsync(requestDomain);
            return CreatedAtAction(nameof(GetById), new { id = requestDomain.RequestID }, mapper.Map<RequestDTO>(requestDomain));
        }

      

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var requestDomain = await requestRepository.GetByIdAsync(id);

            if (requestDomain == null)
            {
                return NotFound();
            }

            await requestRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
