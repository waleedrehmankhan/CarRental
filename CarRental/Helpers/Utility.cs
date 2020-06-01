using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Helpers
{
    public static class Utility
    {

        public static bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
        public static string ConvertToDatetime(string value)
        {
            DateTime date;
            DateTime.TryParse(value, out date);
            return date.ToString("yyyy/MM/dd hh:mm tt");
        }
        public static bool NotPastDate(string value)
        {
            DateTime date;
            if (DateTime.TryParse(value, out date) && date.Date >= DateTime.Today.Date)
            {
                return true;
            }
            return false;

        }

       public enum PaymentType :int
        {
            Cash = 1,
            Cheque = 2,
            BankDeposit = 3,
        }

        public enum InvoiceStatus : int
        {
            Invoiced = 1,
            Paid = 2,
            Cancelled = 3,
        }
    }
}
