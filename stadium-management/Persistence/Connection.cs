using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace stadium_management.Persistence
{
    public class Connection
    {
        protected static string ConnectionStringBuilder
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["WindowsAuth"].ToString();
            }
        }
    }
}