using JumpIn.Common.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Admin.Domain.Models.Auction
{
    public class Product : BaseAuditableEntity
    {
        [Required]
        [StringLength(64, ErrorMessage = "The Product name cannot exceed 64 characters.")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "The Product number cannot exceed 4 characters.")]
        public string ProductNumber { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The Color name cannot exceed 15 characters.")]
        public string Color { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "The Size cannot exceed 5 characters.")]
        public string Size { get; set; }

        public decimal Weight { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        [Required]
        public byte[] ThumbnailPhoto { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The Thumbnail Photo File name cannot exceed 25 characters.")]
        public string ThumbnailPhotoFileName { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The Additional details cannot exceed 250 characters.")]
        public string AdditionalDetail { get; set; }
        public int DutchAuctionId { get; set; }

        public DutchAuction DutchAuction { get; set; }
    }
}
