import { CarDto } from "./CarDto";
import { BranchDto } from "./BranchDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class LocationDto {
        
        // Id
        public Id: number = 0;
        // Car
        public Car: CarDto = null;
        // Branch
        public Branch: BranchDto = null;
        // isAtLocation
        public isAtLocation: boolean = false;
        // CarId
        public CarId: number = 0;
        // BranchId
        public BranchId: number = 0;
    }

