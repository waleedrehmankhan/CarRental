﻿
 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class ExtraDto {
        
        // ExtraId
        public ExtraId: number = 0;
        // Name
        public Name: string = null;
        // Price
        public Price: number = 0;
        // Count
        public Count: number = 0;
        // PriceType
        public PriceType: number = 0;
    }

