using AutoMapper;
using Disaster_Response_System.CustomActionFilter;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disaster_Response_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _requestService.GetAllRequestsAsync();
            return Ok(requests);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = await _requestService.GetRequestByIdAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] RequestFormDTO requestDTO)
        {
            try
            {
                await _requestService.AddRequestAsync(requestDTO);
                return Ok();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _requestService.DeleteRequestAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
