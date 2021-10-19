using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.OutMethods
{
    public class GetAdministratorsOut : BaseMethodOut
    {
        public List<Administrator> Administrators { get; set; }
        public int TotalRows { get; set; }
    }
}