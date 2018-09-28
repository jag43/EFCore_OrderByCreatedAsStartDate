using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models.Enums
{
    public enum TelemCallStatus
    {
        Undefined = 0,
        Pending = 1,
        InCall = 2,
        NoInterest = 3,
        GoneAway = 4,
        Callback = 5,
        InvalidNumber = 6,
        Completed = 7,
        OptOutAll = 20,
        OptOutNeverCall = 21
    }
}
