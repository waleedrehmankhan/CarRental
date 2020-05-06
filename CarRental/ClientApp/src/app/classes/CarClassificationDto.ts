
 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class CarClassificationDto {
        
        // Id
        public Id: number = 0;
        // PassengerCount
        public PassengerCount: number = 0;
        // CostPerHour
        public CostPerHour: number = 0;
        // CostPerDay
        public CostPerDay: number = 0;
        // LateFeePerHour
        public LateFeePerHour: number = 0;
    }

