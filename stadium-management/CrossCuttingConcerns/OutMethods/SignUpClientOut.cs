using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stadium_management.CrossCuttingConcerns.OutMethods
{
    public class SignUpClientOut : BaseMethodOut
    {
        public Client Client { get; set; }
    }
}