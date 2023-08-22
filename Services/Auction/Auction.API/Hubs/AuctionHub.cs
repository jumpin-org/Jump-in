using JumpIn.Auction.BusinessLogicLayer.CommandHandlers;
using JumpIn.Auction.BusinessLogicLayer.Commands;
using JumpIn.Auction.BusinessLogicLayer.QueryHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JumpIn.Auction.API.Hubs
{
    public class AuctionHub : Hub
    {
        private int auctionId = -1;
        private int currentPrice = 0;
        private int bidderCount = 0;

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("RecieveMesage", $"{Context.ConnectionId} has joined the auction");
        }

        public async Task StartAuction(int auctionId,
           [FromServices] StartDutchAuctionCommandHandler handler)
        {
            this.auctionId = await handler.Handle(new StartDutchAuctionCommand(auctionId));

            await Clients.All.SendAsync("AuctionStarted", currentPrice);
        }

        public async Task JoinAuctionRoom(string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"AuctionRoom-{auctionId}");
            await Clients.OthersInGroup($"AuctionRoom-{auctionId}").SendAsync("UserJoined", userName);
            await Clients.Caller.SendAsync("AuctionStarted", currentPrice);
        }

        public async Task PlaceBid(int bidAmount)
        {
            if (bidAmount > currentPrice)
            {
                currentPrice = bidAmount;
                await Clients.Group($"AuctionRoom-{auctionId}").SendAsync("BidPlaced", currentPrice);
            }
        }

        public async Task EndAuction()
        {
            await Clients.All.SendAsync("AuctionEnded", currentPrice);
        }

        public async Task LeaveAuctionRoom(string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"AuctionRoom-{auctionId}");
            await Clients.OthersInGroup($"AuctionRoom-{auctionId}").SendAsync("UserLeft", userName);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await LeaveAuctionRoom(Context.User.Identity.Name);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
