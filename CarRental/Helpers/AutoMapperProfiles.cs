using AutoMapper;
using CarRental.Dtos;
using CarRental.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<MembershipType, MembershipTypeDto>();

            // Dto to Domain
            CreateMap<CustomerDto, Customer>();
               // .ForMember(c => c.CustomerID, opt => opt.Ignore());


            CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<CarDto, Car>();
            CreateMap<Car, CarDto>();


            CreateMap<BookingDto, Booking>();
            CreateMap<Booking, BookingDto>();

            CreateMap<BranchDto, Branch>();
            CreateMap<Branch, BranchDto>();

            CreateMap<ExtraDto, Extra>();

            CreateMap<Extra, ExtraDto>();


            CreateMap<RegisterUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, RegisterUserDto>();

            CreateMap<IdentityRole, IdentityRoleDto>();
            CreateMap<IdentityRoleDto, IdentityRole>();
        }
    }
}