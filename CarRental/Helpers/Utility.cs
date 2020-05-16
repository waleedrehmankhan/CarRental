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
        public static DateTime ConvertToDatetime(string value)
        {
            DateTime date;
            DateTime.TryParse(value, out date);
            return date;
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
    }
}
