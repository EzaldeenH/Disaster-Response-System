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
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _donorService.GetAllDonorsAsync();
            return Ok(donors);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var donor = await _donorService.GetDonorByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return Ok(donor);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddDonorDTO donorDTO)
        {
            await _donorService.AddDonorAsync(donorDTO);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddDonorDTO donorDTO)
        {
            try
            {
                await _donorService.UpdateDonorAsync(id, donorDTO);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _donorService.DeleteDonorAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
