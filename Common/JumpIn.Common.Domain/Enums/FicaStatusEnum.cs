using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Common.Domain.Enums
{
    public enum FicaStatusEnum
    {
        [Description("Not Started")]
        NotStarted = 1,

        [Description("In Progress"),]
        InProgress,

        [Description("Pending")]
        Pending,

        [Description("Verified")]
        Verified,

        [Description("Rejected")]
        Rejected,

        [Description("Expired")]
        Expired,

        [Description("Suspended")]
        Suspended,

        [Description("Closed")]
        Closed
    }
}
