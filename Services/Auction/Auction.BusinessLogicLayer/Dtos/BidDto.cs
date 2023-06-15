using JumpIn.Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.BusinessLogicLayer.Dtos
{
    public class BidDto
    {
        private BidDto() { }

        public BidDto(int bidderId, int dutchAuctionId, decimal amount, DateTime bidTime, BidStatusEnum bidStatus)
        {
            BidderId = bidderId;
            DutchAuctionId = dutchAuctionId;
            Amount = amount;
            BidTime = bidTime;
            BidStatus = bidStatus;
        }

        public int BidderId { get; set; }

        public int DutchAuctionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        public BidStatusEnum BidStatus { get; set; }
    }
}
