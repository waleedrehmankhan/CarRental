import { InvoiceDto } from "./InvoiceDto";
import { CarDto } from "./CarDto";
import { ExtraDto } from "./ExtraDto";
import { PaymentDto } from "./PaymentDto";
import { BookingDto } from "./BookingDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class InvoiceDetailDto {
        
        // InvoiceId
        public InvoiceId: number = 0;
        // Invoice
        public Invoice: InvoiceDto = null;
        // Car
        public Car: CarDto = null;
        // BookingExtraList
        public BookingExtraList: ExtraDto[] = [];
        // Payment
        public Payment: PaymentDto = null;
        // Booking
        public Booking: BookingDto = null;
    }

