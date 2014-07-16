namespace ReestrFacade.Configurations
{
    using System;
    using System.Configuration;

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
