import { BookingDto } from "./BookingDto";
import { ExtraDto } from "./ExtraDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class BookingExtraDto {
        
        // Id
        public Id: number = 0;
        // Booking
        public Booking: BookingDto = null;
        // Extra
        public Extra: ExtraDto = null;
        // Count
        public Count: number = 0;
        // ExtraId
        public ExtraId: number = 0;
        // BookingId
        public BookingId: number = 0;
        // Price
        public Price: number = 0;
    }

