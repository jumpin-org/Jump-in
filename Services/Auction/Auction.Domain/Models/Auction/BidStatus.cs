using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class BidStatus: BaseStatusModel
    {
        private BidStatusEnum id;

        private BidStatus()
           : base()
        {
        }

        public  BidStatusEnum Id
        {
            get => id;

            set
            {
                id = value;
                Name = value.GetEnumDescription();
            }
        }

        public IEnumerable<Bid> Bids { get; } = new List<Bid>();
    }
}
