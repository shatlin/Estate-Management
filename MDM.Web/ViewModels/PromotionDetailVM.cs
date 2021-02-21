using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class PromotionDetailVM
    {
        public int Id { get; set; }
        public int PromotionMasterId { get; set; }
        public string PromotionMasterName { get; set; }
        public int? MembershipGradeId { get; set; }
        public string MembershipGradeName { get; set; }
        public int? MemberLevelId { get; set; }
        public string MemberLevelName { get; set; }
        public decimal DiscountPercentage { get; set; }
        

    }


}
