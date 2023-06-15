using JumpIn.Common.Domain.Enums;

namespace JumpIn.Common.Domain.Dtos.OutputDtos
{
    public class BidOutputDto
    {
        private BidOutputDto()
        {
        }

        public BidOutputDto(int bidId, decimal amount, DateTime bidTime, BidStatusEnum bidStatus)
        {
            BidId = bidId;
            Amount = amount;
            BidTime = bidTime;
            BidStatus = bidStatus;
        }

        public int BidId { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        public BidStatusEnum BidStatus { get; set; }
    }
}
