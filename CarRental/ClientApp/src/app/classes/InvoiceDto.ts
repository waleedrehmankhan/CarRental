import { CustomerDto } from "./CustomerDto";
import { BookingDto } from "./BookingDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class InvoiceDto {
        
        // Id
        public Id: number = 0;
        // Customer
        public Customer: CustomerDto = null;
        // Booking
        public Booking: BookingDto = null;
        // InvoiceNumber
        public InvoiceNumber: string = null;
        // IssueDate
        public IssueDate: string = null;
        // DueDate
        public DueDate: string = null;
        // Amount
        public Amount: number = 0;
        // Description
        public Description: string = null;
        // CustomerId
        public CustomerId: number = 0;
        // BookingId
        public BookingId: number = 0;
        // status
        public status: boolean = false;
        // CreatedOn
        public CreatedOn: Date = new Date(0);
        // CreatedBy
        public CreatedBy: string = null;
    }

