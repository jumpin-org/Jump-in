using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Common.Domain.Model
{
    public abstract class BaseAuditableEntity
    {
        public DateTime DateCreated { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? DateLastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}
