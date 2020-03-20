using AutoMapper;
using CarRental.Dtos;
using CarRental.Models;

namespace CarRental.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}