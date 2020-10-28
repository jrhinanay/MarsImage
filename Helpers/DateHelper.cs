using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsImage.Helpers
{
    public static class DateHelper
    {
        private static readonly string[] validPattern = { 
            "MM/dd/yy",
            "MMMM dd, yyyy",
            "MMM-dd-yyyy",
            "MMMM d, yyyy"
        };
        public static string FormatDate(string rawDate, string datePattern) {
            string pattern = GetCorrectPattern(rawDate);
            if (string.IsNullOrEmpty(pattern)) {
                return null;
            }
            DateTime newDate = DateTime.ParseExact(rawDate, pattern, System.Globalization.CultureInfo.InvariantCulture);

            return newDate.ToString(datePattern);
        }

        private static string GetCorrectPattern(string rawDate) {
            string pattern = string.Empty;

            int i = 0;
            while (i < validPattern.Length) {
                try
                {
                    DateTime.ParseExact(rawDate, validPattern[i],System.Globalization.CultureInfo.InvariantCulture);
                    pattern = validPattern[i];
                    break;
                }
                catch
                {

                }
                i++;
            }
        
            return pattern;
        }
    }
}
