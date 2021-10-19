using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public class Constants
    {
        public class SessionKeys
        {
            public static string IsAdmin = "IsAdmin";
            public static string LoggedAdministrator = "LoggedAdministrator";
            public static string LoggedClient = "LoggedClient";
        }
    }
}