using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Dtos
{
    public class CustomerDto
    {
       
        public int Id { get; set; }
      
        public string CustomerCode { get; set; }

     
        public string FirstName { get; set; }
 
        public string MiddleName { get; set; }
 
        public string LastName { get; set; }
        
        public string EmailAddress { get; set; }

         
        public string PhoneNumber { get; set; }

        
        public DateTime? BirthDate { get; set; }

         
        public string LicenseNumber { get; set; }

        public bool isSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
       
        public byte MembershipTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}