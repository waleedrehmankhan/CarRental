import { CustomerDto } from "./CustomerDto";
import { BranchDto } from "./BranchDto";
import { BookingExtraDto } from "./BookingExtraDto";
import { CarDto } from "./CarDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class BookingDto {
        
        // Id
        public Id: number = 0;
        // Customer
        public Customer: CustomerDto = null;
        // FromBranch
        public FromBranch: BranchDto = null;
        // ToBranch
        public ToBranch: BranchDto = null;
        // bookingextras
        public bookingextras: BookingExtraDto[] = [];
        // Car
        public Car: CarDto = null;
        // FromDate
        public FromDate: string = null;
        // ReturnDate
        public ReturnDate: string = null;
        // isActive
        public isActive: string = null;
        // Status
        public Status: string = null;
        // CustomerId
        public CustomerId: number = 0;
        // CarId
        public CarId: number = 0;
        // FromBranchID
        public FromBranchID: number = 0;
        // ToBranchID
        public ToBranchID: number = 0;
        // IsNewCustomer
        public IsNewCustomer: boolean = false;
    }

