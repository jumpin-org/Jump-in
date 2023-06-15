using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Domain.Model;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Admin
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
                Name = value.GetEnumName();
                Description = value.GetEnumFullDescription();
            }
        }

        public static FicaStatus Create(FicaStatusEnum id)
        {
            return new FicaStatus() { Id = id};
        }

        public IEnumerable<FicaDetail> FicaDetails { get; } = new List<FicaDetail>();
    }
}
