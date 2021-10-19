using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.OutMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.Model
{
    public class Clients
    {
        public static SignInClientOut SignInClient(Client input)
        {
            return Persistence.Clients.SignInClient(input);
        }

        public static SignUpClientOut SignUpClient(Client input)
        {
            return Persistence.Clients.SignUpClient(input);
        }
    }
}