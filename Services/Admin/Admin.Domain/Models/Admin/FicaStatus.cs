using JumpIn.Admin.Domain.Models.Auction;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Common.Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class FicaStatus : BaseStatusModel
    {
        private FicaStatusEnum id;

        private FicaStatus() 
            : base()
        {
        }

        public FicaStatusEnum Id
        {
            get => id;

            set
            {
                id = value;
                Name = value.GetEnumDescription();
            }
        }

        public IEnumerable<FicaDetail> FicaDetails { get; } = new List<FicaDetail>();
    }
}
