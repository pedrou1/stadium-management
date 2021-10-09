using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public class Administrator : User
    {
        public string DocumentNumber { get; set; }
        public string Telephone { get; set; }
    }
}