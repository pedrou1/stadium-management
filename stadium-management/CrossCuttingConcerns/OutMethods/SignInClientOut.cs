﻿using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.OutMethods
{
    public class SignInClientOut : BaseMethodOut
    {
        public Client Client { get; set; }
    }
}