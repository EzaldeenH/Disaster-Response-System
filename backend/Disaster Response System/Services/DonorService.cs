using AutoMapper;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
using Disaster_Response_System.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disaster_Response_System.Services
{
    public class DonorService : IDonorService
    {
        private readonly IGenericRepository<Donor> _donorRepository;
        private readonly IMapper _mapper;

        public DonorService(IGenericRepository<Donor> donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DonorDTO>> GetAllDonorsAsync()
        {
            var donors = await _donorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DonorDTO>>(donors);
        }

        public async Task<DonorDTO> GetDonorByIdAsync(Guid id)
        {
            var donor = await _donorRepository.GetByIdAsync(id);
            return _mapper.Map<DonorDTO>(donor);
        }

        public async Task AddDonorAsync(AddDonorDTO donorDTO)
        {
            var donor = _mapper.Map<Donor>(donorDTO);
            await _donorRepository.CreateAsync(donor);
        }

        public async Task UpdateDonorAsync(Guid id, AddDonorDTO donorDTO)
        {
            var donor = await _donorRepository.GetByIdAsync(id);

            if (donor == null)
            {
                throw new KeyNotFoundException("Donor not found");
            }

            donor.Name = donorDTO.Name;
            donor.Organization = donorDTO.Organization;

            await _donorRepository.UpdateAsync(donor);
        }

        public async Task DeleteDonorAsync(Guid id)
        {
            await _donorRepository.DeleteAsync(id);
        }
    }
}
