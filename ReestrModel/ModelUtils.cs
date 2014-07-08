using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReestrModel
{
    using ReestrModel.Properties;

    public class ModelUtils
    {
        public static string ConnectionString
        {
            get
            {
                return Settings.Default.ReestrStoreConnectionString;
            }
        }
    }
}
