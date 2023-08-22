using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Enums;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.BusinessLogicLayer.Commands
{
    public class StartDutchAuctionCommand : ICommand<int>
    {
        public StartDutchAuctionCommand(int auctionId)
        {
            AuctionId = auctionId;
        }

        public int AuctionId { get; private set; }
    }
}
