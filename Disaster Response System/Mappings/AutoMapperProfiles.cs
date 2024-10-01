using AutoMapper;
using Disaster_Response_System.Models.Domain;
using Disaster_Response_System.Models.DTO;
namespace Disaster_Response_System.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Donor, DonorDTO>().ReverseMap();
            CreateMap<AddDonorDTO, Donor>().ReverseMap();
            CreateMap<Donation, DonationDTO>().ReverseMap();
            CreateMap<AddDonationDTO, Donation>().ReverseMap();
            CreateMap<Round, RoundDTO>().ReverseMap();
            CreateMap<AddRoundDTO, Round>().ReverseMap();
        }
    }
}
