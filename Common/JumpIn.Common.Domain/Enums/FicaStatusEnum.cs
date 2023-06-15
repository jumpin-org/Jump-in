using JumpIn.Common.Domain.Enums;
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
        [EnumInfo("Not Started", "FICA verification process has not been initiated.")]
        NotStarted = 1,

        [EnumInfo("In Progress", "FICA verification is in progress.")]
        InProgress,

        [EnumInfo("Pending", "FICA verification is pending and awaiting further action.")]
        Pending,

        [EnumInfo("Verified", "FICA verification has been completed and the individual or entity is verified.")]
        Verified,

        [EnumInfo("Rejected", "FICA verification has been rejected due to failure to meet requirements or provide necessary documentation.")]
        Rejected,

        [EnumInfo("Expired", "FICA verification has expired and needs to be renewed.")]
        Expired,

        [EnumInfo("Suspended", "FICA verification has been temporarily suspended for some reason.")]
        Suspended,

        [EnumInfo("Closed", "FICA verification process has been closed or terminated.")]
        Closed
    }
}
