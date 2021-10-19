using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.CrossCuttingConcerns.Entities
{
    public enum OperationResult
    {
        Error = 0,
        Success = 1,
        UsernameAlreadyExist = 2,
        InvalidUser = 3
    }
}