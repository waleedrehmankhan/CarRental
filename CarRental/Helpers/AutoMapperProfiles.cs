using AutoMapper;
using CarRental.Dtos;
using CarRental.Models;

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
        }
    }
}