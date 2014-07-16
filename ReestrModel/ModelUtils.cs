using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReestrModel
{
    using System.Configuration;

    using ReestrModel.Properties;

    public class ModelUtils
    {
        public static string ConnectionString
        {
            get
            {

                return ConfigurationManager.ConnectionStrings["reestrdb"].ConnectionString;
            }
        }
    }
}
