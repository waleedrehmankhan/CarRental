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

            CreateMap<CarClassificationDto, CarClassification>();
            CreateMap<CarClassification, CarClassificationDto>();

            CreateMap<UserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();

            CreateMap<BookingDto, Booking>();
            CreateMap<Booking, BookingDto>();

            CreateMap<BranchDto, Branch>();
            CreateMap<Branch, BranchDto>();

            CreateMap<ExtraDto, Extra>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExtraId));


            CreateMap<Extra, ExtraDto>()
                 .ForMember(dest => dest.ExtraId, opt => opt.MapFrom(src => src.Id));


            CreateMap<BookingExtraDto, BookingExtra>();
            CreateMap<BookingExtra, BookingExtraDto>();
            CreateMap<RegisterUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, RegisterUserDto>();

            CreateMap<IdentityRole, IdentityRoleDto>();
            CreateMap<IdentityRoleDto, IdentityRole>();

            CreateMap<InvoiceDto, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();

            CreateMap<ServiceHistory, ServiceHistoryDto>();
            CreateMap<ServiceHistoryDto, ServiceHistory>();
        }
    }
}