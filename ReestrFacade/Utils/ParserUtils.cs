using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrFacade.Utils
{
    public class ParserUtils
    {
        public static DateTime ParseDateTime(string valueString)
        {
            return DateTime.Parse(valueString);
        }
    }
}
