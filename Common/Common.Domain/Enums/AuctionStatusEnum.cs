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

        [Description("Active")]
        Active,

        [Description("Started")]
        Started,

        [Description("In Progress")]
        InProgress,

        [Description("Ended")]
        Ended,

        [Description("Closed")]
        Closed,

        [Description("Deactivated")]
        Deactivated,
    }
}
