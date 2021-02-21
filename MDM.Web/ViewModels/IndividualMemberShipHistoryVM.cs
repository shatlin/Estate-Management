using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberShipHistoryVM
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? MemberId { get; set; }
        public string MemberShipChangeReasonName { get; set; }
        public string MembershipTypeName { get; set; }
        public string MemberShipGradeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }

    }
}

