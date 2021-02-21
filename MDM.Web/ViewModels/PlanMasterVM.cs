using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class PlanMasterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }
        public bool? IsLimited { get; set; }
        public int? LimitToMemberCount { get; set; }
        public bool ApplyTaxSettings { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public bool CanPublicApply { get; set; }

    }


}
