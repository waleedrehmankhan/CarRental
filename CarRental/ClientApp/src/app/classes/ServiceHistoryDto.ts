import { CarDto } from "./CarDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class ServiceHistoryDto {
        
        // Id
        public Id: number = 0;
        // Car
        public Car: CarDto = null;
        // DueDate
        public DueDate: Date = new Date(0);
        // Status
        public Status: boolean = false;
        // Description
        public Description: string = null;
        // CarId
        public CarId: number = 0;
        // CreatedOn
        public CreatedOn: Date = new Date(0);
        // CreatedBy
        public CreatedBy: string = null;
    }

