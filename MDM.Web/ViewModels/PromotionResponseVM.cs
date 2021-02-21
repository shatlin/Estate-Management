using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class PromotionResponseVM
    {
        public int Id { get; set; }
        public int PromotionMasterId { get; set; }
        public string PromotionMasterName { get; set; }
        public int MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public int PromotionResponseTypeId { get; set; }
        public string PromotionResponseTypeName { get; set; }
        public DateTime ResponseDate { get; set; }
    }


}
