using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class FicaDetail : BaseAuditableEntity
    {
        public int FicaDetailId { get; set; }
        public byte[]? IDDocument { get; set; }
        public byte[]? ProofAddress { get; set; }
        public FicaStatusEnum FicaStatusId { get; set; }
        public FicaStatus FicaStatus { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
