using AutoMapper;
using CarRental.Dtos;
using CarRental.Models;

namespace CarRental.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            
            CreateMap<Customer, CustomerDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            

            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}