using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class FicaStatus
    {
        public FicaStatusEnum ficaStatusId;

        private FicaStatus()
        {
        }

        public FicaStatusEnum FicaStatusId
        {
            get => ficaStatusId;

            set
            {
                ficaStatusId = value;
                Name = value.GetEnumDescription();
            }
        }

        [StringLength(25, ErrorMessage = "The Name value cannot exceed 25 characters.")]
        public string Name { get; set; }

        [StringLength(128, ErrorMessage = "The Description value cannot exceed 128 characters.")]
        public string Description { get; private set; }

        public ICollection<FicaDetail> FicaDetaila { get; private set; }
    }
}
