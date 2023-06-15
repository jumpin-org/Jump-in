using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Product : BaseAuditableEntity
    {
        private Product()
        { }

        [Required]
        [StringLength(64, ErrorMessage = "The Product name cannot exceed 64 characters.")]
        public string ProductName { get; private set; }

        [Required]
        [StringLength(4, ErrorMessage = "The Product number cannot exceed 4 characters.")]
        public string ProductNumber { get; private set; }

        [Required]
        [StringLength(15, ErrorMessage = "The Color name cannot exceed 15 characters.")]
        public string Color { get; private set; }

        [Required]
        [StringLength(5, ErrorMessage = "The Size cannot exceed 5 characters.")]
        public string Size { get; private set; }

        public decimal Weight { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public DateTime? DiscontinuedDate { get; private set; }

        [Required]
        public byte[]? ThumbnailPhoto { get; private set; }

        [Required]
        [StringLength(25, ErrorMessage = "The Thumbnail Photo File name cannot exceed 25 characters.")]
        public string ThumbnailPhotoFileName { get; private set; }

        [Required]
        [StringLength(250, ErrorMessage = "The Additional details cannot exceed 250 characters.")]
        public string AdditionalDetail { get; private set; }

        public int DutchAuctionId { get; set; }

        public DutchAuction DutchAuction { get; set; }


        public static Product Create(string productName, string productNumber, string color, string size, decimal weight, decimal currentPrice, DateTime? discontinuedDate, byte[]? thumbnailPhoto, string thumbnailPhotoFileName, string additionalDetail)
        {
            return new Product()
            {
                ProductName = productName,
                ProductNumber = productNumber,
                Color = color,
                Size = size,
                Weight = weight,
                CurrentPrice = currentPrice,
                DiscontinuedDate = discontinuedDate,
                ThumbnailPhoto = thumbnailPhoto,
                ThumbnailPhotoFileName = thumbnailPhotoFileName,
                AdditionalDetail = additionalDetail,
            };
        }

    }
}
