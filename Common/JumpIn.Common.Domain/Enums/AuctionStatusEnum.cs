using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Common.Domain.Enums
{
    public enum AuctionStatusEnum
    {
        [Description("New")]
        New = 1,

        [Description("Started")]
        Active = 2,

        [Description("In Progress")]
        InProgress = 3,

        [Description("Complete")]
        Complete = 4,

        [Description("Deactivated")]
        Deactivated = 5,
    }
}
