import { InvoiceDto } from "./InvoiceDto";

 

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class PaymentDto {
        
        // Id
        public Id: number = 0;
        // Invoice
        public Invoice: InvoiceDto = null;
        // PaymentDate
        public PaymentDate: Date = new Date(0);
        // ReceiptNumber
        public ReceiptNumber: string = null;
        // TotalAmount
        public TotalAmount: number = 0;
        // GST
        public GST: number = 0;
        // LateFee
        public LateFee: number = 0;
        // PaymentType
        public PaymentType: string = null;
        // Remarks
        public Remarks: string = null;
        // InvoiceId
        public InvoiceId: number = 0;
    }

