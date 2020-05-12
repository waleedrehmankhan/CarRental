
 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class RegistrationDto {
        
        // Id
        public Id: string = null;
        // UserName
        public UserName: string = null;
        // Email
        public Email: string = null;
        // Password
        public Password: string = null;
        // PhoneNumber
        public PhoneNumber: string = null;
        // Phone
        public Phone: string = null;
        // CurrentToken
        public CurrentToken: string = null;
    }

