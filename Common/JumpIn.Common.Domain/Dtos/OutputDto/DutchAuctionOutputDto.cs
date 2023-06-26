
namespace JumpIn.Common.Domain.Dtos.OutputDtos
{
    public class DutchAuctionOutputDto
    {
        private DutchAuctionOutputDto()
        { }

        public DutchAuctionOutputDto(int id, string title, string description, decimal startPrice, decimal currentPrice, DateTime startDateTime, DateTime endDateTime, ProductOutputDto product)
        {
            Id = id;
            Title = title;
            Description = description;
            StartPrice = startPrice;
            CurrentPrice = currentPrice;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Product = product;
        }
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal StartPrice { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public DateTime StartDateTime { get; private set; }

        public DateTime EndDateTime { get; private set; }

        public ProductOutputDto Product { get; private set; }
    }
}
