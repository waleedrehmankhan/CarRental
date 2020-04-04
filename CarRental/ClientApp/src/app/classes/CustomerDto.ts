import { MembershipTypeDto } from "./MembershipTypeDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class CustomerDto {
        
        // CUSTOMERID
        public customerID: number = 0;
        // CUSTOMERCODE
        public customerCode: string = null;
        // FIRSTNAME
        public firstName: string = null;
        // MIDDLENAME
        public middleName: string = null;
        // LASTNAME
        public lastName: string = null;
        // EMAILADDRESS
        public emailAddress: string = null;
        // PHONENUMBER
        public phoneNumber: string = null;
        // BIRTHDATE
        public birthDate: Date = null;
        // LICENSENUMBER
        public licenseNumber: string = null;
        // ISSUBSCRIBEDTONEWSLETTER
        public isSubscribedToNewsLetter: boolean = false;
        // MEMBERSHIPTYPE
        public membershipType: MembershipTypeDto = null;
        // MEMBERSHIPTYPEID
        public membershipTypeId: number = 0;
    }
