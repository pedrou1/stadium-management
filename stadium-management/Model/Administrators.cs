using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.InMethods;
using stadium_management.CrossCuttingConcerns.OutMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.Model
{
    public class Administrators
    {
        public static SignInAdministratorOut SignInAdministrator(Administrator input)
        {
            return Persistence.Administrators.SignInAdministrator(input);
        }

        public static AddAdministratorOut AddAdministrator(Administrator input)
        {
            return Persistence.Administrators.AddAdministrator(input);
        }

        public static GetAdministratorsOut GetAdministrators(GetAdministratorsIn input)
        {
            return Persistence.Administrators.GetAdministrators(input);
        }

        public static DeleteAdministratorOut DeleteAdministrator(Administrator input)
        {
            return Persistence.Administrators.DeleteAdministrator(input);
        }

        public static GetAdministratorByIdOut GetAdministratorById(Administrator input)
        {
            return Persistence.Administrators.GetAdministratorById(input);
        }

        public static UpdateAdministratorOut UpdateAdministrator(Administrator input)
        {
            return Persistence.Administrators.UpdateAdministrator(input);
        }
    }
}