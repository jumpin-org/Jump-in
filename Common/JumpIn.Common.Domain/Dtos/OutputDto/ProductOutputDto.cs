
namespace JumpIn.Common.Domain.Dtos.OutputDtos
{
    public class ProductOutputDto
    {
        private ProductOutputDto()
        { }

        public ProductOutputDto(string productName, string productNumber, string color, string size, decimal weight, decimal currentPrice, DateTime? discontinuedDate, byte[]? thumbnailPhoto, string thumbnailPhotoFileName, string additionalDetail)
        {
            ProductName = productName;
            ProductNumber = productNumber;
            Color = color;
            Size = size;
            Weight = weight;
            CurrentPrice = currentPrice;
            DiscontinuedDate = discontinuedDate;
            ThumbnailPhoto = thumbnailPhoto;
            ThumbnailPhotoFileName = thumbnailPhotoFileName;
            AdditionalDetail = additionalDetail;
        }

        public string ProductName { get; private set; }

        public string ProductNumber { get; private set; }

        public string Color { get; private set; }

        public string Size { get; private set; }

        public decimal Weight { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public DateTime? DiscontinuedDate { get; private set; }

        public byte[]? ThumbnailPhoto { get; private set; }

        public string ThumbnailPhotoFileName { get; private set; }

        public string AdditionalDetail { get; private set; }
    }
}
