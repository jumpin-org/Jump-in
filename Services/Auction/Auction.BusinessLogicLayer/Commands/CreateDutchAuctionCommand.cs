using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.BusinessLogicLayer.Commands
{
    public class CreateDutchAuctionCommand : ICommand<int>
    {

        public int AccountId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal StartPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal Decrement { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string ProductName { get; set; }

        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public decimal Weight { get; set; }

        public decimal CurrentProductPrice { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        public byte[]? ThumbnailPhoto { get; set; }

        public string ThumbnailPhotoFileName { get; set; }

        public string AdditionalDetail { get; set; }

    }
}
