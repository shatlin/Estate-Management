using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class PromotionMasterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BenefitStartDate { get; set; }
        public DateTime BenefitEndDate { get; set; }
        public bool IsActive { get; set; }
        public int RelatedToId { get; set; }
        public string RelatedToName { get; set; }
    }


}
