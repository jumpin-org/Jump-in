﻿using JumpIn.Admin.Domain.Models.Auction;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class Account : BaseAuditableEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public FicaDetail FicaDetail { get; set; }

        public Seller Seller { get; set; }

        public Bidder Bidder { get; set; }
    }
}
