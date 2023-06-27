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
        Placed,

        [Description("Active")]
        Active,

        [Description("Highest")]
        Highest,

        [Description("Lowest")]
        Lowest,

        [Description("Revoked")]
        Revoked,

        [Description("Invalid")]
        Invalid

    }
}
