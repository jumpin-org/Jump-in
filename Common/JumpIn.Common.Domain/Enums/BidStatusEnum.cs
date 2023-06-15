using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Common.Domain.Enums
{
    public enum BidStatusEnum
    {
        [Description("New")]
        New = 1,

        [Description("Placed")]
        Placed = 2,

        [Description("Active")]
        Active = 3,

        [Description("Highest")]
        Highest = 4,

        [Description("Lowest")]
        Lowest = 5,

        [Description("Revoked")]
        Revoked = 6,

        [Description("Invalid")]
        Invalid = 7,
    }
}
