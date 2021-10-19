using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.InMethods;
using stadium_management.CrossCuttingConcerns.OutMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.Model
{
    public class Facade
    {
        public static SignInClientOut SignInClient(Client input)
        {
            return Clients.SignInClient(input);
        }

        public static SignUpClientOut SignUpClient(Client input)
        {
            return Clients.SignUpClient(input);
        }

        public static SignInAdministratorOut SignInAdministrator(Administrator input)
        {
            return Administrators.SignInAdministrator(input);
        }

        public static AddAdministratorOut AddAdministrator(Administrator input)
        {
            return Administrators.AddAdministrator(input);
        }

        public static GetAdministratorsOut GetAdministrators(GetAdministratorsIn input)
        {
            return Administrators.GetAdministrators(input);
        }

        public static DeleteAdministratorOut DeleteAdministrator(Administrator input)
        {
            return Administrators.DeleteAdministrator(input);
        }

        public static GetAdministratorByIdOut GetAdministratorById(Administrator input)
        {
            return Administrators.GetAdministratorById(input);
        }

        public static UpdateAdministratorOut UpdateAdministrator(Administrator input)
        {
            return Administrators.UpdateAdministrator(input);
        }
    }
}