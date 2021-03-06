import { MembershipTypeDto } from "./MembershipTypeDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class CustomerDto {
        
        // Id
        public Id: number = 0;
        // CustomerCode
        public CustomerCode: string = null;
        // FirstName
        public FirstName: string = null;
        // MiddleName
        public MiddleName: string = null;
        // LastName
        public LastName: string = null;
        // EmailAddress
        public EmailAddress: string = null;
        // PhoneNumber
        public PhoneNumber: string = null;
        // BirthDate
        public BirthDate: Date = null;
        // LicenseNumber
        public LicenseNumber: string = null;
        // isSubscribedToNewsLetter
        public isSubscribedToNewsLetter: boolean = false;
        // MembershipType
        public MembershipType: MembershipTypeDto = null;
        // MembershipTypeId
        public MembershipTypeId: number = 0;
        // CreatedOn
        public CreatedOn: Date = new Date(0);
        // CreatedBy
        public CreatedBy: string = null;
    }

