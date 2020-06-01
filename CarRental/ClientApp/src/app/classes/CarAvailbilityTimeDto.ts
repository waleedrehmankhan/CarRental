
 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class CarAvailbilityTimeDto {
        
        // time
        public time: string = null;
        // IsAvailable
        public IsAvailable: boolean = false;
        // BookingId
        public BookingId: number = 0;
        // CarId
        public CarId: number = 0;
        // Hour
        public Hour: number = 0;
        // Date
        public Date: Date = new Date(0);
    }

