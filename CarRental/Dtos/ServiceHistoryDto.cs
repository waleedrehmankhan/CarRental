using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class ServiceHistoryDto
    {
        public int Id { get; set; }
        public CarDto Car { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
 
        public int CarId { get; set; }
        public int ServicingType { get; set; }
        public double Amoune { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


        public string ServiceStatus
        {
            get
            {
                return Status == true ? "Completed" : "Due";


            }


        }
        public string ServicingTypeName
        {
            get
            {
                string name = "";
                switch(ServicingType)
                {
                    case 1:
                        name = "Tyre Replacement";
                        break;
                    case 2:
                        name = "Mobil Change";
                        break;
                    case 3:
                        name = "Brake Fix";
                        break;
                    case 4:
                        name = "Fuel Fill";
                        break;
                    case 5:
                        name = "Other";
                        break;
                    default:
                        name = "";
                        break;

                }

                return name;

                 


            }


        }
    }
}
