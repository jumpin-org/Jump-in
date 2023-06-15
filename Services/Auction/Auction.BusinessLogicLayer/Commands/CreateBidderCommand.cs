//using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Auction.BusinessLogicLayer.Commands
{
    public class CreateBidderCommand : ICommand<int>
    {
        public CreateBidderCommand(int accountId)
        {
            AccountId = accountId;
        }

        public int AccountId { get; set; }
    }
}
