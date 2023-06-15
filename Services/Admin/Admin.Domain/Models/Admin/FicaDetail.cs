using JumpIn.Admin.Domain.Models.Auction;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class FicaDetail : BaseAuditableEntity
    {
        private FicaDetail()
        {
        }

        public byte[]? IDDocument { get; set; }

        public byte[]? ProofAddress { get; set; }

        public FicaStatus FicaStatus { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public static FicaDetail Create(byte[]? iDDocument, byte[]? proofAddress, FicaStatus ficaStatus)
        {
            return new FicaDetail() 
            { 
                IDDocument = iDDocument,
                ProofAddress = proofAddress,
                FicaStatus = ficaStatus
            };
        }
    }
}
