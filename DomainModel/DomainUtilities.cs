using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class DomainUtilities
    {
        internal static  bool IsSaturday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday;
        }

        internal static bool IsSunday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday ;
        }

        internal static DateTime CorrectSaturday(DateTime date)
        {
            return date.AddDays(2);
        }

        internal static DateTime CorrectSunday(DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
