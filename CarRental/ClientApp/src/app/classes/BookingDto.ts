import { CustomerDto } from "./CustomerDto";
import { BranchDto } from "./BranchDto";
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
        // Car
        public Car: CarDto = null;
        // FromDate
        public FromDate: Date = new Date(0);
        // ReturnDate
        public ReturnDate: Date = new Date(0);
        // ActualReturnDate
        public ActualReturnDate: Date = new Date(0);
        // isActive
        public isActive: boolean = false;
        // CustomerId
        public CustomerId: number = 0;
        // CarId
        public CarId: number = 0;
        // FromBranchID
        public FromBranchID: number = 0;
        // ToBranchID
        public ToBranchID: number = 0;
    }

