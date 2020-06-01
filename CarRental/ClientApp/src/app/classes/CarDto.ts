import { CarClassificationDto } from "./CarClassificationDto";
import { CarAvailbilityTimeDto } from "./CarAvailbilityTimeDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class CarDto {
        
        // Id
        public Id: number = 0;
        // RegistrationNumber
        public RegistrationNumber: string = null;
        // Year
        public Year: number = 0;
        // Make
        public Make: string = null;
        // Model
        public Model: string = null;
        // Mileage
        public Mileage: number = 0;
        // isAvailable
        public isAvailable: boolean = false;
        // isActive
        public isActive: boolean = false;
        // CarClassification
        public CarClassification: CarClassificationDto = null;
        // Image
        public Image: string = null;
        // CarAvailability
        public CarAvailability: CarAvailbilityTimeDto[] = [];
    }

